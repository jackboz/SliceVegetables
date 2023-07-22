using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SliceVegetables.UI
{
    [RequireComponent(typeof(Slider))]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] float initialValue = 0;
        Slider slider;
        Image fillArea;

        void Awake()
        {
            slider = gameObject.GetComponent<Slider>();
            slider.value = initialValue;
            fillArea = transform.Find("Fill Area/Fill").GetComponent<Image>();
            if (fillArea == null)
            {
                Debug.LogError("Cound't find \"Fill Area/Fill\" Image component");
            }
        }

        public void SetProgress(float newProgress)
        {
            slider.value = Mathf.Clamp01(newProgress);
        }

        public void ChangeColor(string color)
        {
            Color newCol;
            if (ColorUtility.TryParseHtmlString(color, out newCol))
            {
                fillArea.color = newCol;
            }
        }
    }
}