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
        }

        private void TrackKeyboard()
        {
            AnimationPlayer.PlayerStay(true, _animator);
            AnimationPlayer.PlayerRun(false, _animator);

            var weapon = Inventory.GetItemInHand()?.GetComponent<Weapon>();
            KeystrokeMovement(weapon);
            KeystrokeMovementAcceleration();
            KeystrokeShoot(weapon);
            KeystrokeReload(weapon);
        }

        private void KeystrokeShoot(Weapon weapon)
        {
            if (!IsAnimationReloadPlaying())
            {
                if (Input.GetMouseButton(0))
                {
                    if (weapon != null) weapon.ShootAutomaticWeapon();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (weapon != null) weapon.ShootNotAutomaticWeapon();
                }
            }
        }

        private void KeystrokeReload(Weapon weapon)
        {
            AnimationPlayer.PlayerReload(false, _animator);
            if (Input.GetKeyDown(KeyCode.R))
            {
                var isReload = false;
                if (weapon != null)
                {
                    isReload = weapon.Reload();
                }
                AnimationPlayer.PlayerReload(isReload, _animator);
            }
        }

        private void KeystrokeMovementAcceleration()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _movement.Jump(_animator, _rigidbody);
            }
        }

        private void KeystrokeMovement(Weapon weapon)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                var horizontal = Input.GetAxis(Axis.Horizontal);
                var vertical = Input.GetAxis(Axis.Vertical);
                _movement.Move(new Vector3(horizontal, 0, vertical));

                AnimationPlayer.PlayerHoldItem(weapon, _animator);
                AnimationPlayer.PlayerStay(false, _animator);
                AnimationPlayer.PlayerRun(true, _animator);
            }
        }
        
        private bool IsAnimationReloadPlaying() 
        {        
            var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            return animatorStateInfo.IsName("Reload");
        }
    }
}
