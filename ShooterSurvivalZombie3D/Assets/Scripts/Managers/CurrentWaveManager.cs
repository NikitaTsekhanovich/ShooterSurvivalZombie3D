using UnityEngine.Events;
using UnityEngine;

namespace Managers
{
    public class CurrentWaveManager : MonoBehaviour
    {
        public static UnityEvent<int> OnCurrentWave = new UnityEvent<int>();

        public static void SendCurrentWave(int currentWave)
        {
            OnCurrentWave?.Invoke(currentWave);
        }
    }
}
