using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            LoadScreen.SwitchToScene("MainScene");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
