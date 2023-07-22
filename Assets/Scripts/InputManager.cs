using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] Transform _knife;
        [SerializeField] SlicerCollider slicerCollider;
        Animator _knifeAnim;

        bool _isOn = false;
        bool _isHitWood = false;
        float[] _speedLevels = new float[] { 1f, 1.5f, 2f, 2.5f, 3f };
        int _speedLevel = 0;

        public void TurnOn()
        {
            _isOn = true;
        }
        public void TurnOff()
        {
            _isOn = false;
            slicerCollider.IsSlicing = false;
            _knifeAnim.Play("Default");
        }

        void Awake()
        {
            if (_knife == null)
            {
                Debug.LogError("Knife Transform is not set");
            }
            _knifeAnim = _knife.GetComponent<Animator>();
            if (_knifeAnim == null)
            {
                Debug.LogWarning("Knife does not have animator component");
            }
            if (slicerCollider == null)
            {
                Debug.LogError("SlicerCollider component is not set");
            }
        }

        void Update()
        {
            if (!_isOn) return;

            if (_isHitWood) return;

            if (Input.GetMouseButtonDown(0))
            {
                _knifeAnim.SetFloat("speedCoeff", _speedLevels[_speedLevel]);
                _knifeAnim.Play("Cut");
                slicerCollider.IsSlicing = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _knifeAnim.Play("Default");
                slicerCollider.IsSlicing = false;
            }
        }

        public void HitWood()
        {
            _isHitWood = true;
            _knifeAnim.Play("WoodHit");
            slicerCollider.IsSlicing = false;
        }

        public void DisableHitWood()
        {
            _isHitWood = false;
        }

        public void SetSpeedLevel(int level)
        {
            if ((level >= 0) && (level < 5))
            {
                _speedLevel = level;
            }
        }
    }
}