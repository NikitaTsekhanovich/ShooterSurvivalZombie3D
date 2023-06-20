using UnityEngine;

namespace Player.InventoryEntities.Weapons
{
    [CreateAssetMenu(
        fileName = "Automatic Weapon Item", 
        menuName="Inventory/Items/New Automatic Weapon Item"
    )]
    public class AutomaticWeaponItem : ItemScriptableObject
    {
        public AutomaticWeaponItem()
        {
            ItemType = ItemType.AutomaticWeapon;
        }
    }
}
