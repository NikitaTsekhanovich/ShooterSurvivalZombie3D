using System;
using Managers;
using Player.MainPlayer;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Indicators
{
    public class HealthBarPlayer : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private AudioSource _applyDamage;
        private float _healthAmount;

        private void Start()
        {
            _healthAmount = 100;
            _healthBar.fillAmount = _healthAmount / 100;

            PlayerHealthManager.OnPlayerApplyDamage.AddListener(damage =>
            {
                _healthBar.fillAmount -= damage / 100f;
                _applyDamage.Play();
                if (_healthBar.fillAmount <= 0)
                {
                    Time.timeScale = 0;
                }
            });
        }
    }
}
