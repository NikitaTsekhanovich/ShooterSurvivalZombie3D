using UnityEngine;

namespace Player.InventoryEntities.Weapons
{
    [CreateAssetMenu(
        fileName = "Not Automatic Weapon Item", 
        menuName="Inventory/Items/New Not Automatic Weapon Item"
    )]
    public class NotAutomaticWeaponItem : ItemScriptableObject
    {
        public NotAutomaticWeaponItem()
        {
            ItemType = ItemType.NotAutomaticWeapon;
        }
    }
}