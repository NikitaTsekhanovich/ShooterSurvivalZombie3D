using UnityEngine;

namespace Cameras
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] private float _sensitivtyMouse;
        [SerializeField] private float _bottomLimit;
        [SerializeField] private float _upLimit;

        private float _mouseX;
        private float _mouseY;
        private float _xRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        private void Update()
        {
            _mouseX = Input.GetAxis("Mouse X") * _sensitivtyMouse * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * _sensitivtyMouse * Time.deltaTime;
            
            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, _upLimit, _bottomLimit);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            Player.MainPlayer.Player.PlayerSingleton.transform.Rotate(Vector3.up, _mouseX);
        }
    }
}