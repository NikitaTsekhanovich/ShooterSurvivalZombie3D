using Player.InventoryEntities;
using Player.InventoryEntities.Weapons;
using UnityEngine;

namespace Player.MainPlayer
{
    public class ActionWeapon : MonoBehaviour
    {
        private bool _isReload;
        private float _weaponReloadTime;
        private float _shotInterval;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        internal void Shoot()
        {
            if (!_isReload)
            {
                var itemInHand = Inventory.GetItemInHand();
                if (itemInHand != null)
                {
                    if (itemInHand.GetComponent<Item>().item.ItemType == ItemType.AutomaticWeapon)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            _shotInterval += Time.deltaTime;
                        
                            if (_shotInterval >= itemInHand.GetComponent<Weapon>().ShotDelay)
                            {
                                itemInHand.GetComponent<Weapon>().ShootWeapon(_camera);
                                _shotInterval = 0;
                            }
                        }
                    }
                    if (itemInHand.GetComponent<Item>().item.ItemType == ItemType.NotAutomaticWeapon)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            itemInHand.GetComponent<Weapon>().ShootWeapon(_camera);
                        }
                    }
                }
            }
            else
            {
                _weaponReloadTime += Time.deltaTime;
                if (_weaponReloadTime >= 3)
                { 
                    _isReload = false;
                    _weaponReloadTime = 0;
                }
            }
        }
        
        internal void Reload(Animator animator)
        {
            AnimationPlayer.PlayerReload(_isReload, animator);
            if (Input.GetKeyDown(KeyCode.R))
            {
                var itemInHand = Inventory.GetItemInHand();
                if (itemInHand != null)
                {
                    if (itemInHand.GetComponent<Item>().item.ItemType == ItemType.AutomaticWeapon ||
                        itemInHand.GetComponent<Item>().item.ItemType == ItemType.NotAutomaticWeapon)
                    {
                        _isReload = itemInHand.GetComponent<Weapon>().IsReload();
                        AnimationPlayer.PlayerReload(_isReload, animator);
                    }
                }
            }
        }
    }
}
