using Managers;
using UnityEngine;
using UnityEngine.UI;


namespace Player.Indicators
{
    public class ZombiesAliveScore : MonoBehaviour
    {
        //private int _alive;

        private void Start()
        {
            ZombieAliveManager.OnZombieAlive.AddListener(DrawZombiesAlive);
        }

        private void DrawZombiesAlive(int zombieAlive)
        {
            //_alive += zombieAlive;
            GetComponent<Text>().text = $"Zombies alive: {zombieAlive}";
        }
    }
}
