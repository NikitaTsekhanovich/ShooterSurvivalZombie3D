using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseGameMenu;
        private bool _isPauseGame;

        private PauseMenu()
        {
            _isPauseGame = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPauseGame)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            _isPauseGame = false;
            Time.timeScale = 1f;
            _pauseGameMenu.SetActive(false);
        }

        private void Pause()
        {
            _pauseGameMenu.SetActive(true);
            Time.timeScale = 0;
            _isPauseGame = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }
}
