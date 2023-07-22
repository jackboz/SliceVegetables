using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SliceVegetables;

namespace SliceVegetables.Animation
{
    public class WoodHitCallback : MonoBehaviour
    {
        [SerializeField] InputManager inputManager;

        void Awake()
        {
            if (inputManager == null)
            {
                Debug.LogError("Input Manager is not set");
            }
        }

        public void OnWoodHitAnimationEnd()
        {
            inputManager.DisableHitWood();
        }
    }
}
