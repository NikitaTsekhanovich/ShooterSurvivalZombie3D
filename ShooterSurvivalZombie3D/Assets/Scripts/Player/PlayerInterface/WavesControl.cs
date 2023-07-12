using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Player.PlayerInterface
{
    public class WavesControl : MonoBehaviour
    {
        private void Start()
        {
            CurrentWaveManager.OnCurrentWave.AddListener(currentWave =>
            {
                GetComponent<Text>().text = $"Wave: {currentWave}";
            });
        }
    }
}
