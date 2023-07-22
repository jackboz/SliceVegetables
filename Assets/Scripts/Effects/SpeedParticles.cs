using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables
{
    [RequireComponent(typeof(ParticleSystem))]
    public class SpeedParticles : MonoBehaviour
    {
        ParticleSystem _ps;

        float[] _speedLevels = new float[] { 1f, 1f, 6f, 12f, 18f };

        void Awake()
        {
            _ps = GetComponent<ParticleSystem>();
        }

        public void PlayAtSpeedLevel(int level)
        {
            if ((level >= 0) && (level < 2))
            {
                _ps.Stop();
                _ps.Clear();
            }
            else if ((level >= 2) && (level < _speedLevels.Length))
            {
                var main = _ps.main;
                main.startSpeed = _speedLevels[level];
                _ps.Play();
            }
        }
    }
}
