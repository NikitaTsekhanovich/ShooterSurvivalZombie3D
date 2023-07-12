using UnityEngine;

namespace Player.MainPlayer
{
    public class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _endGameMenu;
        [SerializeField] private GameObject _deathMenu;
        [SerializeField] private GameObject _mainPlayerInterface;

        internal GameObject DeathMenu => _deathMenu;
        internal GameObject MainPlayerInterface => _mainPlayerInterface;
        internal GameObject EndGameMenu => _endGameMenu;
    }
}
