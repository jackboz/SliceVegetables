using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables.UI.StateMachine
{
    public class WinLevelState : MonoBehaviour, IUIState
    {
        [SerializeField] GameObject panel;
        [SerializeField] LevelManager levelManager;
        [SerializeField] GameObject _star1;
        [SerializeField] GameObject _star2;
        [SerializeField] GameObject _star3;

        float _winPercent = 0;

        void Start()
        {
            if (panel == null)
            {
                Debug.LogError("UI Panel is not set");
            }
            if (levelManager == null)
            {
                Debug.LogError("Level Manager is not set");
            }
            if ((_star1 == null) || (_star2 == null) || (_star3 == null))
            {
                Debug.LogError("Stars are not set");
            }
        }

        public void OnEnterUIState()
        {
            panel.SetActive(true);
            _winPercent = levelManager.PlayerWon();
            ShowStars();
        }

        public void OnExitUIState()
        {
            levelManager.Restart();
            _star1.SetActive(false);
            _star2.SetActive(false);
            _star3.SetActive(false);
            panel.SetActive(false);
        }

        public void ShowStars()
        {
            if ((_winPercent > 70f) && (!_star1.activeSelf))
            {
                _star1.SetActive(true);
                return;
            }
            if ((_winPercent > 80f) && (!_star2.activeSelf))
            {
                _star2.SetActive(true);
                return;
            }
            if ((_winPercent > 90f) && (!_star3.activeSelf))
            {
                _star3.SetActive(true);
                return;
            }
        }
    }
}