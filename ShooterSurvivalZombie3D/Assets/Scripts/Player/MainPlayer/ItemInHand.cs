using System.Collections.Generic;
using UnityEngine;

namespace Player.MainPlayer
{
    public class ItemInHand : MonoBehaviour
    {
        private static GameObject _hand;
        private static Dictionary<int, GameObject> _itemsInHand;

        private void Awake()
        {
            _hand = GameObject.FindGameObjectWithTag("RightHandIndex1");
            _itemsInHand = new Dictionary<int, GameObject>
            {
                {0, null},
                {1, null},
                {2, null},
                {3, null},
                {4, null},
                {5, null}
            };
        }

        public static void HoldItemHand(GameObject currentItem, int index)
        {
            currentItem.transform.parent = _hand.transform;
            currentItem.transform.localScale = new Vector3(1f, 1f, 1f);
            currentItem.GetComponent<Rigidbody>().isKinematic = true;
            currentItem.transform.localPosition = Vector3.zero;

            if (currentItem.CompareTag("Weapon") || currentItem.CompareTag("Ammo"))
            {
                currentItem.GetComponent<BoxCollider>().enabled = false;
                currentItem.transform.localRotation = Quaternion.Euler(-63f, 143f, -56f);
            }
            if (currentItem.CompareTag("FlashlightColor"))
            {
                currentItem.GetComponent<CapsuleCollider>().enabled = false;
                currentItem.transform.localRotation = Quaternion.Euler(90f, 270f, 0f);
            }
            currentItem.SetActive(false);
            _itemsInHand[index] = currentItem;
        }

        public static GameObject ActiveItemInHand(int index)
        {
            GameObject itemInHand = null;
            foreach (KeyValuePair<int, GameObject> entry in _itemsInHand)
            {
                if (entry.Value != null)
                {
                    if (entry.Key == index)
                    {
                        entry.Value.SetActive(true);
                        itemInHand = entry.Value;
                    }
                    else
                    {
                        entry.Value.SetActive(false);
                    }
                }
            }
            return itemInHand;
        }

        public static void DropItemHand(int index, GameObject itemInHand)
        {
            if (itemInHand.CompareTag("Weapon") || itemInHand.CompareTag("Ammo"))
            {
                itemInHand.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                itemInHand.GetComponent<CapsuleCollider>().enabled = true;
            }
            itemInHand.GetComponent<Rigidbody>().isKinematic = false;
            itemInHand.transform.parent = null;
            itemInHand.transform.localScale = new Vector3(1f, 1f, 1f);
            _itemsInHand[index] = null;
        }
    }
}
