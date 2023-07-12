using UnityEngine.Events;

namespace Player.MainPlayer
{
    public abstract class PlayerHealth
    {
        public static readonly UnityEvent<int> OnPlayerApplyDamage = new UnityEvent<int>();

        public static void SendPlayerApplyDamage(int damage)
        {
            OnPlayerApplyDamage.Invoke(damage);
        }
    }
}