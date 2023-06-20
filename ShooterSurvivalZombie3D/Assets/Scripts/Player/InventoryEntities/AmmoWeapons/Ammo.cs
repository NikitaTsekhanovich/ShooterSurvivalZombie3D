using UnityEngine;

namespace Player.InventoryEntities.AmmoWeapons
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private int _numberAmmo;

        public int NumberAmmo
        {
            get => _numberAmmo;
            set => _numberAmmo = value;
        }
    }
}
