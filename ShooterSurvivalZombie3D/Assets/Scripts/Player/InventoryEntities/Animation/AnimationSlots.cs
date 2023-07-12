using System.Collections.Generic;
using UnityEngine;

namespace Player.InventoryEntities.Animation
{
    public class AnimationSlots : MonoBehaviour
    {
        public static void DoAnimationSlots(List<InventorySlot> slots, int index)
        {
            slots[index].Animator.SetBool("FlashSlot", true);
            for (var i = 0; i < slots.Count; i++)
            {
                if (index != i)
                {
                    slots[i].Animator.SetBool("FlashSlot", false);
                }
            }
        }
    }
}