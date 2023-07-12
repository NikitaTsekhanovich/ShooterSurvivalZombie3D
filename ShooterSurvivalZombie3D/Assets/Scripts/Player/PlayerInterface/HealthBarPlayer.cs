using Player.MainPlayer;
using UnityEngine;
using UnityEngine.UI;

namespace Player.PlayerInterface
{
    public class HealthBarPlayer : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private AudioSource _applyDamageSound;
        [SerializeField] private PlayerDeath _playerDeath;
        private float _healthAmount;

        private void Start()
        {
            _healthAmount = 100;
            _healthBar.fillAmount = _healthAmount / 100;

            PlayerHealth.OnPlayerApplyDamage.AddListener(damage =>
            {
                _healthBar.fillAmount -= damage / 100f;
                _applyDamageSound.Play();
                if (_healthBar.fillAmount <= 0)
                {
                    _playerDeath.PlayerDied();
                }
            });
        }
    }
}
