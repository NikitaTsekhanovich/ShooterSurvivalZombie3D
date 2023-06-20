using System;
using UnityEngine;

namespace WeaponBoxes
{
    public class WeaponBox : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Light _light;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetBool("IsOpen", true);
                _light.gameObject.SetActive(false);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetBool("IsOpen", false);
            }
        }
    }
}
