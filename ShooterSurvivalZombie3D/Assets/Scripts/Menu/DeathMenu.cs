using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class DeathMenu : MonoBehaviour
    {
        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1f;
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}
