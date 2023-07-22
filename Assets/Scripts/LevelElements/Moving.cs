using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables
{
    public class Moving : MonoBehaviour
    {
        [SerializeField] float[] speed = new float[] { 2f, 3f, 4f, 5f, 6f };
        [SerializeField] LevelManager levelManager;

        void Awake()
        {
            if (levelManager == null)
            {
                Debug.LogError("Level Manager is not set");
            }
        }

        void Update()
        {
            transform.Translate(Vector3.forward * speed[levelManager.SpeedLevel] * Time.deltaTime);
        }
    }
}
