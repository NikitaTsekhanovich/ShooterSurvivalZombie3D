using System;
using UnityEngine;

namespace GameEvents
{
    public class BasicGameHint : MonoBehaviour
    {
        [SerializeField] private GameObject _hint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _hint.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _hint.SetActive(false);
            }
        }
    }
}
