using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] AudioSource[] cutAudioSources;
        [SerializeField] LevelManager levelManager;
        [SerializeField] SlicerCollider slicerCollider;

        bool _isPlaying = false;
        int _currentAudioSourceLevel = -1;

        void Awake()
        {
            if (levelManager == null)
            {
                Debug.LogError("Level Manager is not set");
            }
            if (cutAudioSources.Length < 5)
            {
                Debug.LogError("There should be 5 audio sources");
            }
            if (slicerCollider == null)
            {
                Debug.LogError("Slicer Collider is not set");
            }
        }

        void Update()
        {
            if (slicerCollider.IsSlicing)
            {
                PlayCut();
            }
            else
            {
                StopCutSound();
            }
        }

        public void PlayCut()
        {
            if (!_isPlaying)
            {
                cutAudioSources[levelManager.SpeedLevel].enabled = true;
                _currentAudioSourceLevel = levelManager.SpeedLevel;
            }
            else
            if (_currentAudioSourceLevel != levelManager.SpeedLevel )
            {
                StopCutSound();
                cutAudioSources[levelManager.SpeedLevel].enabled = true;
                _currentAudioSourceLevel = levelManager.SpeedLevel;
            }
            _isPlaying = true;
        }

        public void StopCutSound()
        {
            if (!_isPlaying) return;

            foreach (var audioSource in cutAudioSources)
            {
                audioSource.enabled = false;
            }
            _isPlaying = false;
        }
    }
}
