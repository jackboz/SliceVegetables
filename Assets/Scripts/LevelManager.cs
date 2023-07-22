using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SliceVegetables.UI;

namespace SliceVegetables
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] LevelUIController levelUIController;
        [SerializeField] InputManager inputManager;
        [SerializeField] Spawner spawner;
        [SerializeField] SpeedParticles _leftSpeedPS, _rightSpeedPS;

        float _levelTimer = 30f; // 30 sec for a round
        float _levelTime = 0;
        int _slicedParts = 0;
        int _missedParts = 0;

        public int SpeedLevel
        {
            get { return _speedLevel; }
            private set { 
                _speedLevel = value;
                levelUIController.SetSpeedLevel(_speedLevel + 1);
                _leftSpeedPS.PlayAtSpeedLevel(_speedLevel);
                _rightSpeedPS.PlayAtSpeedLevel(_speedLevel);
                inputManager.SetSpeedLevel(_speedLevel);
            }
        }

        int _speedLevel = 0;
        int _basicScore = 3;
        float[] _speedCoeff = new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f };
        int[] _speedLevelUp = new int[] { 300, 600, 1200, 1800 };
        int _endLevelPoints = 2500;
        int _levelScore = 0;
        bool _isRoundStarted = false;

        void Awake()
        {
            if (levelUIController == null)
            {
                Debug.LogError("Set level ui controller");
                return;
            }
            levelUIController.MaxProgressBarScore = _endLevelPoints;
            if (inputManager == null)
            {
                Debug.LogError("Set Input Manager");
            }
            if (spawner == null)
            {
                Debug.LogError("Set Spawner component");
            }
            if (_leftSpeedPS == null)
            {
                Debug.LogWarning("Left Speed PS is not set");
            }
            if (_rightSpeedPS == null)
            {
                Debug.LogWarning("Right Speed PS is not set");
            }
        }

        void Start()
        {
            SpeedLevel = 0;
            _levelScore = 0;
        }

        void Update()
        {
            if (_isRoundStarted)
            {
                _levelTime += Time.deltaTime;
                CheckSpeedLevel();
                CheckWinCondition();
            }
            //Debug.Log("Time " + _levelTime);
        }

        public void StartLevel()
        {
            inputManager.TurnOn();
            spawner.IsLevelOn = true;
            _isRoundStarted = true;
            SpeedLevel = 0;
            _levelScore = 0;
            _levelTime = 0;
            _slicedParts = 0;
            _missedParts = 0;
        }

        public float PlayerWon()
        {
            inputManager.TurnOff();
            spawner.IsLevelOn = false;
            _isRoundStarted = false;
            SpeedLevel = 0;
            levelUIController.SetWinScore(_levelScore);
            float winPercent = 100f * _slicedParts / (_slicedParts + _missedParts);
            levelUIController.SetWinSlicedPercent(winPercent);
            return winPercent;
        }

        public void PlayerLost()
        {
            inputManager.TurnOff();
            spawner.IsLevelOn = false;
            _isRoundStarted = false;
        }

        public void SetLevelToStartMenu()
        {
            inputManager.TurnOff();
            spawner.IsLevelOn = false;
            _isRoundStarted = false;
            //levelUIController.SetLevelScore(_levelScore);
            levelUIController.SetTotalScore(GameProgressStatic.TotalScore);
        }

        public void AddScore()
        {
            _levelScore += (int)(_speedCoeff[SpeedLevel] * _basicScore);
            levelUIController.SetLevelScore(_levelScore);
            _slicedParts += 1;
        }

        public void AddMissed()
        {
            if (!_isRoundStarted) return;
            _missedParts += 1;
        }

        void CheckSpeedLevel()
        {
            if ((SpeedLevel < _speedLevelUp.Length) && (_levelScore >= _speedLevelUp[SpeedLevel]))
            {
                SpeedLevel += 1;
            }
        }

        void CheckWinCondition()
        {
            if ((_levelScore > _endLevelPoints) && (_levelTime > _levelTimer))
            {
                levelUIController.ActivateWinPanel();
            }
        }

        public void Restart()
        {
            GameProgressStatic.TotalScore += _levelScore;
            SpeedLevel = 0;
            _levelScore = 0;
            //using UnityEngine.SceneManagement;
            //SceneManager.LoadScene("Level");
        }
    }
}