using Managers;
using Player.MainPlayer;
using UnityEngine;

namespace ZombiesEntities
{
    public class ZombieAttack : Zombies
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth.SendPlayerApplyDamage(
                    gameObject.GetComponentInParent<ZombieEssence>().Damage);
            }
        }
    }
}
