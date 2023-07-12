using System.Collections.Generic;
using Player.InventoryEntities.AmmoWeapons;
using Player.InventoryEntities.Animation;
using Player.InventoryEntities.Weapons;
using Player.MainPlayer;
using UnityEngine;
using UnityEngine.UI;

namespace Player.InventoryEntities
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform inventoryPanel;
        [SerializeField] private List<InventorySlot> slots;
        
        private float _reachDistance;
        private Camera _mainCamera;
        private int _index;
        private static GameObject _itemInHand;

        private Inventory()
        {
            _reachDistance = 3f;
            slots = new List<InventorySlot>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            CreateSlots();
        }

        private void CreateSlots()
        {
            for (var i = 0; i < inventoryPanel.childCount; i++)
            {
                if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
                {
                    slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
                }
            }
        }

        private void Update()
        {
            UpItem();
            DropItem();
            ShowWeaponAmmo();
            _index = GetIndexSlot();
        }
        
        private void UpItem()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, _reachDistance))
                {
                    if (hit.collider.gameObject.GetComponent<Item>() != null)
                    {
                        AddItemSlot(hit.collider.gameObject.GetComponent<Item>().item, 
                            hit.collider.gameObject);
                    }
                }
            }
        }
        
        private void AddItemSlot(ItemScriptableObject item, GameObject prefab)
        {
            AddNewItemSlot(item, prefab);
            AddAmmoSlot(item, prefab);
        }

        private void AddAmmoSlot(ItemScriptableObject item, GameObject prefab)
        {
            if (item.ItemType == ItemType.Ammo)
            {
                AddAmmoWeapon(prefab);
                SumAmmo(item, prefab);
                AddNewAmmoSlot(item, prefab);
            }
        }

        private void SumAmmo(ItemScriptableObject item, GameObject prefab)
        {
            if (!slots[_index].IsEmpty && slots[_index].Item == item)
            {
                _itemInHand.GetComponent<Ammo>().NumberAmmo += prefab.GetComponent<Ammo>().NumberAmmo;
                slots[_index].NumberRounds.text = _itemInHand.GetComponent<Ammo>().NumberAmmo.ToString();
                Destroy(prefab);
            }
        }

        private void AddNewAmmoSlot(ItemScriptableObject item, GameObject prefab)
        {
            if (slots[_index].IsEmpty)
            {
                slots[_index].Item = item;
                slots[_index].IsEmpty = false;
                slots[_index].SetIcon(item.Icon);
                ItemInHand.HoldItemHand(prefab, _index);
            }
        }

        private void AddAmmoWeapon(GameObject prefab)
        {
            if (!slots[_index].IsEmpty &&
                (_itemInHand.GetComponent<Item>().item.ItemType == ItemType.NotAutomaticWeapon ||
                 _itemInHand.GetComponent<Item>().item.ItemType == ItemType.AutomaticWeapon))
            {
                _itemInHand.GetComponent<Weapon>().ExtraAmmo += prefab.GetComponent<Ammo>().NumberAmmo;
                Destroy(prefab);
            }
        }

        private void AddNewItemSlot(ItemScriptableObject item, GameObject prefab)
        {
            if (item.ItemType == ItemType.Flashlight ||
                item.ItemType == ItemType.AutomaticWeapon ||
                item.ItemType == ItemType.NotAutomaticWeapon)
            {
                if (slots[_index].IsEmpty)
                {
                    slots[_index].Item = item;
                    slots[_index].IsEmpty = false;
                    slots[_index].SetIcon(item.Icon);
                    ItemInHand.HoldItemHand(prefab, _index);
                }
            }
        }

        private void DropItem()
        {
            if (Input.GetKeyDown(KeyCode.Q) && slots[_index].Item != null)
            {
                slots[_index].IsEmpty = true;
                slots[_index].Item = null;
                slots[_index].IconGo.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[_index].IconGo.GetComponent<Image>().sprite = null;
                slots[_index].NumberRounds.text = "";
                slots[_index].NumberMagazine.text = "";
                ItemInHand.DropItemHand(_index, _itemInHand);
            }
        }
        
        private void ShowWeaponAmmo()
        {
            if (_itemInHand != null && slots[_index].Item != null)
            {
                if (slots[_index].Item.ItemType == ItemType.AutomaticWeapon ||
                    slots[_index].Item.ItemType == ItemType.NotAutomaticWeapon)
                {
                    slots[_index].NumberRounds.text = _itemInHand.GetComponent<Weapon>()
                        .NumberRoundsMagazine.ToString();
                    slots[_index].NumberMagazine.text = _itemInHand.GetComponent<Weapon>()
                        .ExtraAmmo.ToString();
                }

                if (slots[_index].Item.ItemType == ItemType.Ammo)
                {
                    slots[_index].NumberRounds.text = _itemInHand.GetComponent<Ammo>()
                        .NumberAmmo.ToString();
                }
            }
        }

        private int GetIndexSlot()
        {
            if (Input.GetKey(KeyCode.Alpha1)) _index = 0;
            if (Input.GetKey(KeyCode.Alpha2)) _index = 1;
            if (Input.GetKey(KeyCode.Alpha3)) _index = 2;
            if (Input.GetKey(KeyCode.Alpha4)) _index = 3;
            if (Input.GetKey(KeyCode.Alpha5)) _index = 4;   
            if (Input.GetKey(KeyCode.Alpha6)) _index = 5;

            _itemInHand = ItemInHand.ActiveItemInHand(_index);

            AnimationSlots.DoAnimationSlots(slots, _index);
            return _index;
        }
        
        public static GameObject GetItemInHand()
        {
            return _itemInHand == null ? null : _itemInHand;
        }
    }
}
