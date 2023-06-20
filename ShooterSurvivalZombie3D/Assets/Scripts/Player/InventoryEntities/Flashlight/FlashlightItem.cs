using UnityEngine;

namespace Player.InventoryEntities.Flashlight
{
    [CreateAssetMenu(
        fileName = "Flashlight Item", 
        menuName="Inventory/Items/New Flashlight Item"
    )]
    public class FlashlightItem : ItemScriptableObject
    {
        public FlashlightItem()
        {
            ItemType = ItemType.Flashlight;
        }
    }
}
