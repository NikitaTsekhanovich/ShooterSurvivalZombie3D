using System;
using JetBrains.Annotations;
using Player.InventoryEntities;
using Player.InventoryEntities.Weapons;
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
        
        internal static void PlayerHoldItem([NotNull] Weapon weapon, Animator animator)
        {
            if (weapon != null)
            {
                if (weapon.ItemType == ItemType.AutomaticWeapon ||
                    weapon.ItemType == ItemType.NotAutomaticWeapon)
                {
                    PlayerHoldLongWeapon(true, animator);
                }

                if (weapon.ItemType == ItemType.Flashlight)
                {
                    PlayerHoldLongWeapon(false, animator);
                }
            }
            else
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
