using System.Collections.Generic;
using Player.InventoryEntities;
using UnityEngine;

namespace Animations
{
    public class AnimationInventoryManager : MonoBehaviour
    {
        public static void DoAnimationSlots(List<InventorySlot> slots, int index)
        {
            slots[index].animator.SetBool("FlashSlot", true);
            for (var i = 0; i < slots.Count; i++)
            {
                if (index != i)
                {
                    slots[i].animator.SetBool("FlashSlot", false);
                }
            }
        }
    }
}
