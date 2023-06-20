using UnityEngine;

namespace Player.MainPlayer
{
    public class SurfaceSlider : MonoBehaviour
    {
        private Vector3 _normal;

        public Vector3 Project(Vector3 forward)
        {
            return forward - Vector3.Dot(forward, _normal) * _normal; 
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                var normal = contact.normal;
                if (IsGround(normal))
                {
                    _normal = normal;
                    break;
                }
            }
        }

        private bool IsGround(Vector3 normal)
        {
            if (normal.x > 0.5) return false;
            if (normal.z > 0.5) return false;
            if (normal.y < 0.1) return false;
            return true;
        }
    }
}
