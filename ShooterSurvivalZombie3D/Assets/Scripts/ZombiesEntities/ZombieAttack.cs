using Managers;
using Player.Indicators;
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
                PlayerHealthManager.SendPlayerApplyDamage(
                    gameObject.GetComponentInParent<ZombieEssence>().Damage);
            }
        }
    }
}
