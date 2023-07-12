using UnityEngine;

namespace Player.MainPlayer
{
    public class PlayerDeath : PlayerInterface
    {
        public void PlayerDied()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            MainPlayerInterface.SetActive(false);
            DeathMenu.SetActive(true);
        }
    }
}
