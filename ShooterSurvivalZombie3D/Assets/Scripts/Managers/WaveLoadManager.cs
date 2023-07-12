using System;
using Spawners;
using UnityEngine;
using WeaponBoxes;

namespace Managers
{
    public class WaveLoadManager : SpawnerZombie
    {
        [SerializeField] private SpawnerWeaponBox _spawnerWeaponBox;
        private static int _numberWave;
        private bool _isStartWave;

        public static bool IsEndGame { get; private set; }

        public WaveLoadManager()
        {
            _numberWave = 0;
            _isStartWave = false;
            IsEndGame = false;
        }

        private void Update()
        {
            LoadWave();
        }

        public static int GetNumberWave() => _numberWave;

        private void LoadWave()
        {
            NextWave();
            if (_numberWave == 1 && _isStartWave)
            {
                SpawnZombie();
                CurrentWaveManager.SendCurrentWave(_numberWave);
                ZombieAliveManager.SendZombieAlive(AmountZombies);
                _spawnerWeaponBox.SpawnBox(_numberWave);
                _isStartWave = false;
            }
            if (_numberWave == 2 && _isStartWave)
            {
                SpawnZombie();
                CurrentWaveManager.SendCurrentWave(_numberWave);
                ZombieAliveManager.SendZombieAlive(AmountZombies);
                _spawnerWeaponBox.SpawnBox(_numberWave);
                _isStartWave = false;
            }
            if (_numberWave == 3 && _isStartWave)
            {
                SpawnZombie();
                CurrentWaveManager.SendCurrentWave(_numberWave);
                ZombieAliveManager.SendZombieAlive(AmountZombies);
                _spawnerWeaponBox.SpawnBox(_numberWave);
                _isStartWave = false;
            }
            if (_numberWave == 4 && _isStartWave)
            {
                SpawnZombie();
                CurrentWaveManager.SendCurrentWave(_numberWave);
                ZombieAliveManager.SendZombieAlive(AmountZombies);
                _spawnerWeaponBox.SpawnBox(_numberWave);
                _isStartWave = false;
            }
            if (_numberWave == 5 && _isStartWave)
            {
                SpawnZombie();
                CurrentWaveManager.SendCurrentWave(_numberWave);
                ZombieAliveManager.SendZombieAlive(AmountZombies);
                _spawnerWeaponBox.SpawnBox(_numberWave);
                _isStartWave = false;
            }

            if (_numberWave == 6)
            {
                IsEndGame = true;
            }
        }
        
        private void NextWave()
        {
            if (AmountZombies <= 0 && !_isStartWave)
            {
                _numberWave += 1;
                _isStartWave = true;
            }
        }
    }
}