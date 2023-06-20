using System.Collections.Generic;
using UnityEngine;

namespace WeaponBoxes
{
    public abstract class WeaponBoxesEntities : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _weaponBoxes;

        protected List<GameObject> GetBoxes()
        {
            return _weaponBoxes;
        }
    }
}