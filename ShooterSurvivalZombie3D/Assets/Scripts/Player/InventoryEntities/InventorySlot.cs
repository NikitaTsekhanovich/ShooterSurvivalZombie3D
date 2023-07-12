using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.InventoryEntities
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public ItemScriptableObject Item { get; set; }
        public bool IsEmpty { get; set; }
        public GameObject IconGo { get; private set; }
        public TMP_Text NumberRounds { get; private set; }
        public TMP_Text NumberMagazine { get; private set; }
        public Animator Animator => _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public InventorySlot()
        {
            IsEmpty = true;
        }

        private void Awake()
        {
            IconGo = transform.GetChild(0).gameObject;
            NumberRounds = transform.GetChild(1).GetComponent<TMP_Text>();
            NumberMagazine = transform.GetChild(2).GetComponent<TMP_Text>();
        }

        public void SetIcon(Sprite icon)
        {
            IconGo.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            IconGo.GetComponent<Image>().sprite = icon;
        }
    }
}
