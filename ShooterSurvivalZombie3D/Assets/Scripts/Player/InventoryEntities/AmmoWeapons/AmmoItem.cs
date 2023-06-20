using UnityEngine;

namespace Player.InventoryEntities.AmmoWeapons
{
    [CreateAssetMenu(
        fileName = "Ammo", 
        menuName="Inventory/Items/New Ammo"
    )]
    public class AmmoItem : ItemScriptableObject
    {
        public AmmoItem()
        {
            ItemType = ItemType.Ammo;
        }
    }
}
