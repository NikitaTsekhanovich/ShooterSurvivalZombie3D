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
        public static int AmountZombies { get; private set; }

        public SpawnerZombie()
        {
            AmountZombies = 0;
        }

        public static void ReduceAmountZombies()
        {
            AmountZombies -= 1;
        }

        protected void SpawnZombie()
        {
            if (AmountZombies == 0)
            {
                if (WaveLoadManager.GetNumberWave() == 1)
                {
                    while (AmountZombies != 4)
                    {
                        SpawnZombieGirl();
                    }
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 2)
                {
                    while (AmountZombies != 8)
                    {
                        SpawnZombieGirl();
                    }
                    while (AmountZombies != 10)
                    {
                        SpawnZombieWarrior();
                    }
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 3)
                {
                    while (AmountZombies != 4)
                    {
                        SpawnZombieGirl();
                    }
                    while (AmountZombies != 8)
                    {
                        SpawnZombieWarrior();
                    }
                    while (AmountZombies != 10)
                    {
                        SpawnZombieParasite();
                    }
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 4)
                {
                    while (AmountZombies != 10)
                    {
                        SpawnZombieGirl();
                    }
                    while (AmountZombies != 14)
                    {
                        SpawnZombieWarrior();
                    }
                    while (AmountZombies != 17)
                    {
                        SpawnZombieParasite();
                    }
                    return;
                }
                if (WaveLoadManager.GetNumberWave() == 5)
                {
                    while (AmountZombies != 10)
                    {
                        SpawnZombieGirl();
                    }
                    while (AmountZombies != 13)
                    {
                        SpawnZombieWarrior();
                    }
                    while (AmountZombies != 18)
                    {
                        SpawnZombieParasite();
                    }
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

            AmountZombies += 1;
        }
        
        private void SpawnZombieWarrior()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieWarrior);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);

            AmountZombies += 1;
        }
        
        private void SpawnZombieParasite()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieParasite);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);
            
            AmountZombies += 1;
        }
        
        private void SpawnZombieSkeletonBoss()
        {
            var spawnPoint = GetSpawnPoint();
            
            var zombie = Instantiate(ZombieSkeletonBoss);
            zombie.transform.position = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);
            
            AmountZombies += 1;
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
