using Player.InventoryEntities;
using Player.InventoryEntities.Weapons;
using UnityEngine;

namespace Player.MainPlayer
{
    public class Player : MonoBehaviour
    {
        public static Player PlayerSingleton { get; private set; }

        [SerializeField] private Animator _animator;
        [SerializeField] private PhysicsMovement _movement;
        [SerializeField] private ActionWeapon _actionWeapon;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            PlayerSingleton = this;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = new Vector3(0, 0, 0);
        }

        private void Update()
        {
            TrackKeyboard();
            _actionWeapon.Shoot();
            _actionWeapon.Reload(_animator);
        }
        
        private void TrackKeyboard()
        {
            AnimationPlayer.PlayerStay(true, _animator);
            AnimationPlayer.PlayerRun(false, _animator);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                var horizontal = Input.GetAxis(Axis.Horizontal);
                var vertical = Input.GetAxis(Axis.Vertical);
                _movement.Move(new Vector3(horizontal, 0, vertical));

                var typeItemInHand = Inventory.GetItemInHand()?.GetComponent<Item>().item.ItemType;

                AnimationPlayer.PlayerHoldItem(_animator, typeItemInHand);
                AnimationPlayer.PlayerStay(false, _animator);
                AnimationPlayer.PlayerRun(true, _animator);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _movement.Jump(_animator, _rigidbody);
            }
        }
    }
}
