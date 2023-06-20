using Player.InventoryEntities;
using UnityEngine;

namespace Player.MainPlayer
{
    public static class AnimationPlayer
    {
        internal static void PlayerJump(bool isJump, Animator animator)
        {
            animator.SetBool("IsJump", isJump);
        }

        internal static void PlayerReload(bool isReload, Animator animator)
        {
            animator.SetBool("IsReload", isReload);
        }

        internal static void PlayerStay(bool isStay, Animator animator)
        {
            animator.SetBool("IsStay", isStay);
        }

        internal static void PlayerRun(bool isRun, Animator animator)
        {
            animator.SetBool("IsRun", isRun);
        }
        
        internal static void PlayerHoldItem(Animator animator, ItemType? typeItemInHand)
        {
            if (typeItemInHand == ItemType.AutomaticWeapon ||
                typeItemInHand == ItemType.NotAutomaticWeapon)
            {
                PlayerHoldLongWeapon(true, animator);
            }

            if (typeItemInHand == null || typeItemInHand == ItemType.Flashlight)
            {
                PlayerHoldLongWeapon(false, animator);
            }
        }

        private static void PlayerHoldLongWeapon(bool hasWeapon, Animator animator)
        {
            animator.SetBool("WithLongWeapon", hasWeapon);
        }
    }
}
