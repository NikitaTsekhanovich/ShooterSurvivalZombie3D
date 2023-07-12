using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu.GameSettings
{
    public class MusicVolume : MonoBehaviour
    {
        public AudioMixerGroup _mixer;
        [SerializeField] private Slider _musicSlider;

        private void Start()
        {
            _musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(); });
        }

        public void ChangeMusicVolume()
        {
            _mixer.audioMixer.SetFloat("Mixer", Mathf.Lerp(-80, 0, _musicSlider.value));
        }
    }
}
