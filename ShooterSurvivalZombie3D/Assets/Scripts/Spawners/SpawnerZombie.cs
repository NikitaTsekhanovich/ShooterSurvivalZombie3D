using System;
using Managers;
using UnityEngine;
using ZombiesEntities;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SpawnerZombie : Zombies
    {
        [SerializeField] private Transform spawnPointFirst;
        [SerializeField] private Transform spawnPointSecond;
        [SerializeField] private Transform spawnPointThird;

        protected void SpawnZombie()
        {
            if (WaveLoadManager.AmountZombies == 0)
            {
                if (WaveLoadManager.GetNumberWave() == 1)
                {
                    while (WaveLoadManager.AmountZombies != 4)
                    {
                        SpawnZombieGirl();
                    }
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 2)
                {
                    while (WaveLoadManager.AmountZombies != 8)
                    {
                        SpawnZombieGirl();
                    }
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 3)
                {
                    while (WaveLoadManager.AmountZombies != 4)
                    {
                        SpawnZombieGirl();
                    }
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    SpawnZombieParasite();
                    SpawnZombieParasite();
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 4)
                {
                    while (WaveLoadManager.AmountZombies != 10)
                    {
                        SpawnZombieGirl();
                    }
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    SpawnZombieParasite();
                    SpawnZombieParasite();
                    SpawnZombieParasite();
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 5)
                {
                    while (WaveLoadManager.AmountZombies != 10)
                    {
                        SpawnZombieGirl();
                    }
                    SpawnZombieWarrior();
                    SpawnZombieWarrior();
                    SpawnZombieParasite();
                    SpawnZombieParasite();
                    SpawnZombieParasite();
                    SpawnZombieParasite();
                    SpawnZombieSkeletonBoss();
                    return;
                }
            }
        }

        private void SpawnZombieGirl()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieGirl);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);

            WaveLoadManager.AmountZombies += 1;
        }
        
        private void SpawnZombieWarrior()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieWarrior);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);

            WaveLoadManager.AmountZombies += 1;
        }
        
        private void SpawnZombieParasite()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieParasite);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);
            
            WaveLoadManager.AmountZombies += 1;
        }
        
        private void SpawnZombieSkeletonBoss()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieSkeletonBoss);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);
            
            WaveLoadManager.AmountZombies += 1;
        }

        private Transform GetSpawnPoint()
        {
            var point = Random.Range(0, 3);

            return point switch
            {
                0 => spawnPointFirst,
                1 => spawnPointSecond,
                2 => spawnPointThird,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
