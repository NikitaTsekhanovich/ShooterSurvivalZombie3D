using UnityEngine;

namespace Player.MainPlayer
{
    public class InteractionGround : MonoBehaviour
    {
        private bool _onGround;

        public bool GetCheckOnGround() => _onGround;

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _onGround = false;
            }
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag("Ground"))
            {
                _onGround = true;
            }
        }
    }
}
