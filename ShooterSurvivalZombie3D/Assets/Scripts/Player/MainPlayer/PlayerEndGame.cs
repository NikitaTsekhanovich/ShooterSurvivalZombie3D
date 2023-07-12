using Managers;
using UnityEngine;

namespace Player.MainPlayer
{
    public class PlayerEndGame : PlayerInterface
    {
        private void Update()
        {
            FinishGame();
        }

        private void FinishGame()
        {
            if (WaveLoadManager.IsEndGame)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                MainPlayerInterface.SetActive(false);
                EndGameMenu.SetActive(true);
            }
        }
    }
}
