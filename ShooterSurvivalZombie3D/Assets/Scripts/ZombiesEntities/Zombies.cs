using UnityEngine;

namespace ZombiesEntities
{
    public class Zombies : MonoBehaviour
    {
        [SerializeField] private ZombieGirl zombieGirl;
        [SerializeField] private ZombieParasite zombieParasite;
        [SerializeField] private ZombieWarrior zombieWarrior;
        [SerializeField] private ZombieSkeletonBoss zombieSkeletonBoss;

        protected ZombieGirl ZombieGirl => zombieGirl;
        protected ZombieParasite ZombieParasite => zombieParasite;
        protected ZombieWarrior ZombieWarrior => zombieWarrior;
        protected ZombieSkeletonBoss ZombieSkeletonBoss => zombieSkeletonBoss;
    }
}
