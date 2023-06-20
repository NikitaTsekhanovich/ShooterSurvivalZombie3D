using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.InventoryEntities
{
    public class InventorySlot : MonoBehaviour
    {
        public ItemScriptableObject item;
        public bool isEmpty;
        public GameObject iconGO;
        public TMP_Text NumberRounds;
        public TMP_Text NumberMagazine;
        [SerializeField] public Animator animator;


        public InventorySlot()
        {
            isEmpty = true;
        }

        private void Awake()
        {
            iconGO = transform.GetChild(0).gameObject;
            NumberRounds = transform.GetChild(1).GetComponent<TMP_Text>();
            NumberMagazine = transform.GetChild(2).GetComponent<TMP_Text>();
        }

        public void SetIcon(Sprite icon)
        {
            iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            iconGO.GetComponent<Image>().sprite = icon;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
    }
}
