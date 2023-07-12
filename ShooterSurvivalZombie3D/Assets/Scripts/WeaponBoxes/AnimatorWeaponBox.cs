using UnityEngine;

namespace WeaponBoxes
{
    public static class AnimatorWeaponBox
    {
        internal static void OpenWeaponBox(Animator animator)
        {
            animator.SetBool("IsOpen", true);
        }

        internal static void CloseWeaponBox(Animator animator)
        {
            animator.SetBool("IsOpen", false);
        }
    }
}
