using UnityEngine;

namespace Player.MainPlayer
{
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private InteractionGround _interactionGround;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        private readonly float _jumpHeight;

        private PhysicsMovement()
        {
            _jumpHeight = 4f;
        }

        internal void Move(Vector3 direction)
        {
            var directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            var offset = directionAlongSurface * (_speed * GetAcceleration() * Time.deltaTime);
            
            transform.Translate(offset, Space.Self);
        }

        internal void Jump(Animator animator, Rigidbody rigidbody)
        {
            if (_interactionGround.GetCheckOnGround())
            {
                rigidbody.velocity = new Vector3(0, _jumpHeight, Input.GetAxis("Vertical")/10);
                AnimationPlayer.PlayerJump(true, animator);
            }
            else
            {
                AnimationPlayer.PlayerJump(false, animator);
            }
        }
        
        private float GetAcceleration() => Input.GetKey(KeyCode.LeftShift) ? _acceleration : 1;
    }
}
