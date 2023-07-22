using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables.UI.StateMachine
{
    public class LevelUIState : MonoBehaviour, IUIState
    {
        [SerializeField] GameObject panel;
        [SerializeField] LevelManager levelManager;
        [SerializeField] ProgressBar progressBar;

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
            if (progressBar == null)
            {
                Debug.LogError("Progress Bar is not set");
            }
        }

        public void OnEnterUIState()
        {
            panel.SetActive(true);
            levelManager.StartLevel();
        }

        public void OnExitUIState()
        {
            panel.SetActive(false);
            progressBar.ChangeColor("#3BFF6B");
        }
    }

}