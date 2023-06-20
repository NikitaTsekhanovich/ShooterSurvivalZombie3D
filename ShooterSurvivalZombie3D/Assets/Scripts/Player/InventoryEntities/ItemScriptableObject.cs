using UnityEngine;

namespace Player.InventoryEntities
{
    public enum ItemType
    {
        Flashlight,
        Healer,
        AutomaticWeapon,
        NotAutomaticWeapon,
        Ammo,
        Void
    }
    public class ItemScriptableObject : ScriptableObject
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private ItemType itemType;

        public Sprite Icon => icon;
        public ItemType ItemType { get => itemType; protected set => itemType = value; }
    }
}
