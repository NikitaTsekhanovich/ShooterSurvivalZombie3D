using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.GameSettings
{
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private Dropdown resolutionDropdown;
        [SerializeField] private Dropdown qualityDropdown;
        private float _currentVolume;
        private Resolution[] _resolutions;

        private void Start()
        {
            resolutionDropdown.ClearOptions();
            var options = new List<string>();
            _resolutions = Screen.resolutions;
            var currentResolutionIndex = 0;

            for (var i = 0; i < _resolutions.Length; i++)
            {
                var option = _resolutions[i].width + "x" +
                             _resolutions[i].height + " " +
                             _resolutions[i].refreshRate + "Hz";
                options.Add(option);

                if (_resolutions[i].width == Screen.currentResolution.width && 
                    _resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.RefreshShownValue();
            LoadSettings(currentResolutionIndex);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void SetResolution(int resolutionIndex)
        {
            var resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width,
                      resolution.height, Screen.fullScreen);
        }


        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt("QualitySettingPreference",
                       qualityDropdown.value);
            PlayerPrefs.SetInt("ResolutionPreference",
                       resolutionDropdown.value);
            PlayerPrefs.SetInt("FullscreenPreference",
                       System.Convert.ToInt32(Screen.fullScreen));
            PlayerPrefs.SetFloat("VolumePreference",
                       _currentVolume);
        }

        private void LoadSettings(int currentResolutionIndex)
        {
            qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingPreference") ? 
                PlayerPrefs.GetInt("QualitySettingPreference") : 3;
            
            resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? 
                PlayerPrefs.GetInt("ResolutionPreference") : currentResolutionIndex;
            
            Screen.fullScreen = !PlayerPrefs.HasKey("FullscreenPreference") || 
                                System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        }
    }
}
