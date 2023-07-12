using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseGameMenu;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _gameplayInfoMenu;
        private bool _isPauseGame;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPauseGame) Resume();
                else Pause();
            }
        }

        public void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            
            _isPauseGame = false;
            Time.timeScale = 1f;
            _pauseGameMenu.SetActive(false);
            _settingsMenu.SetActive(false);
            _gameplayInfoMenu.SetActive(false);
        }

        private void Pause()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            _pauseGameMenu.SetActive(true);
            Time.timeScale = 0;
            _isPauseGame = true;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }
}
