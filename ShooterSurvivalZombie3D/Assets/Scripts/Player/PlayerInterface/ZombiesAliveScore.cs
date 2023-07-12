using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Player.PlayerInterface
{
    public class ZombiesAliveScore : MonoBehaviour
    {
        private void Start()
        {
            ZombieAliveManager.OnZombieAlive.AddListener(DrawZombiesAlive);
        }

        private void DrawZombiesAlive(int zombieAlive)
        {
            GetComponent<Text>().text = $"Zombies alive: {zombieAlive}";
        }
    }
}
