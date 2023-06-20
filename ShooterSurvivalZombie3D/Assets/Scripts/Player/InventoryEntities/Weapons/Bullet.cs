using System;
using UnityEngine;
using ZombiesEntities;

namespace Player.InventoryEntities.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private readonly float _timeBulletLife = 7f;

        private void Awake()
        {
            Destroy(gameObject, _timeBulletLife);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Zombie"))
            {
                collision.gameObject.GetComponent<ZombieEssence>()
                    .ApplyDamage(Inventory.GetItemInHand()
                        .GetComponent<Weapon>().Damage);
            }
            
            if (!collision.gameObject.CompareTag("Bullet") && 
                !collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
