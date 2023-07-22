using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SliceVegetables.UI.StateMachine;
using TMPro;

namespace SliceVegetables.UI
{
    public class LevelUIController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreLabel;
        [SerializeField] TextMeshProUGUI speedLabel;
        [SerializeField] TextMeshProUGUI totalScoreLabel;
        [SerializeField] TextMeshProUGUI winScoreLabel;
        [SerializeField] TextMeshProUGUI winSlicedLabel;
        [SerializeField] ProgressBar progressBar;

        public int MaxProgressBarScore { get; set; } = 4000;

        UIStateMachineController stateMachineController = new UIStateMachineController();

        void Awake()
        {
            if (scoreLabel == null)
            {
                Debug.LogError("Score Label is not set");
            }
            if (speedLabel == null)
            {
                Debug.LogError("Speed Label is not set");
            }
            if (totalScoreLabel == null)
            {
                Debug.LogError("Total Score Label is not set");
            }
            if (winScoreLabel == null)
            {
                Debug.LogError("Win Score Label is not set");
            }
            if (progressBar == null)
            {
                Debug.LogError("Progress Bar is not set");
            }
            if (winSlicedLabel == null)
            {
                Debug.LogError("Sliced Label is not set");
            }
        }

        void Start()
        {
            IUIState[] states = GetComponents<IUIState>();
            stateMachineController.Init(states);
            if (states.Length == 0)
            {
                Debug.LogError("No UI states attached to LevelUIController game object");
            }
        }

        void Update()
        {

        }

        public void StartButtonClick()
        {
            stateMachineController.SwitchUI(UIStates.Level);
        }

        public void SetLevelScore(int score)
        {
            scoreLabel.SetText(score.ToString());
            progressBar.SetProgress((float)score / MaxProgressBarScore);
            if (score > MaxProgressBarScore)
            {
                progressBar.ChangeColor("#FF8C3B");
            }
        }
        
        public void SetSpeedLevel(int lvl)
        {
            speedLabel.SetText("x" + lvl.ToString());
        }

        public void SetTotalScore(int score)
        {
            totalScoreLabel.SetText(score.ToString());
        }

        public void SetWinScore(int score)
        {
            winScoreLabel.SetText(score.ToString());
        }

        public void SetWinSlicedPercent(float number)
        {
            winSlicedLabel.SetText("SLICED " + number.ToString("F1") + "%");
        }

        public void ActivateWinPanel()
        {
            stateMachineController.SwitchUI(UIStates.Win);
        }

        public void RestartLevel()
        {
            stateMachineController.SwitchUI(UIStates.Start);
        }
    }
}
