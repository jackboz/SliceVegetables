using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SliceVegetables.UI.StateMachine;

namespace SliceVegetables.UI
{
    public class WinStars : MonoBehaviour
    {
        [SerializeField] WinLevelState winLevelState;

        void Awake()
        {
            if (winLevelState == null)
            {
                Debug.LogError("WinLevelState is not set");
            }
        }

        public void ShowStar()
        {
            winLevelState.ShowStars();
        }
    }
}