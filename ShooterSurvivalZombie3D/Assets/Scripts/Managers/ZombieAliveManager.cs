using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class ZombieAliveManager : MonoBehaviour
    {
        public static UnityEvent<int> OnZombieAlive = new UnityEvent<int>();

        public static void SendZombieAlive(int amountZombieAlive)
        {
            OnZombieAlive?.Invoke(amountZombieAlive);
        }
    }
}
