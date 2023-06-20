using UnityEngine;

namespace Player.InventoryEntities.Healers
{
    [CreateAssetMenu(
        fileName = "Food Item", 
        menuName="Inventory/Items/New Food Item"
        )]

    public class HealerItem : ItemScriptableObject
    {
        public float healAmount;

        public HealerItem()
        {
            ItemType = ItemType.Healer;
        }
    }
}
