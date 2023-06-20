using System;
using UnityEngine;

namespace Cameras
{
    public class MainCamera : MonoBehaviour
    {
        private float _mouseX;
        private float _mouseY;
        private float _sensitivtyMouse;
        private float _bottomLimit;
        private float _upLimit;
        private float _xRotation;
        public Transform player;

        private void Start()
        {
            _bottomLimit = 67.62f;
            _upLimit = -90f;
            _sensitivtyMouse = 80f; 
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
            player.Rotate(Vector3.up, _mouseX);
        }
    }
}