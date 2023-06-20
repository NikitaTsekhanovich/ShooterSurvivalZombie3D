using System;
using UnityEngine;

namespace Weather
{
    public class Thunder : MonoBehaviour
    {
        [SerializeField] private Light _thunder;
        [SerializeField] private float _lightningInterval;
        [SerializeField] private float _lightningDuration;
        [SerializeField] private AudioSource _thuderAudio;

        private void Update()
        {
            if (Time.time % _lightningInterval >= _lightningInterval - _lightningDuration)
            {
                _thuderAudio.Play();
                _thunder.intensity = Time.deltaTime * 10f;
            }
            else
            {
                _thunder.intensity = 0f;
            }
        }
    }
}
