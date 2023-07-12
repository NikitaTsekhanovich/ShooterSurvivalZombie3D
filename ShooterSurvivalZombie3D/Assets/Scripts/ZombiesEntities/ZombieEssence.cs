using Managers;
using Player.MainPlayer;
using Spawners;
using UnityEngine;
using UnityEngine.AI;

namespace ZombiesEntities
{
    public abstract class ZombieEssence : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float health;
        [SerializeField] protected float attackRange;
        [SerializeField] protected Animator animator;
        [SerializeField] protected AudioSource screamZombieSound;
        protected float distance;
        protected NavMeshAgent agent;
        protected bool isAttack;
        protected Transform playerTransform;
        private bool _isDied;
        private float _timer;
        
        public int Damage => damage;
        
        private void Start()
        {
            playerTransform = Player.MainPlayer.Player.PlayerSingleton.transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            screamZombieSound.Play();
        }

        public void Update()
        {
            Move();
            Attack();
            Died();
        }

        protected abstract void Move();

        protected abstract void Attack();
        

        public void ApplyDamage(float damagePlayer)
        {
            health -= damagePlayer;
            if (health <= 0)
            {
                _isDied = true;
            }
        }

        private void Died()
        {
            if (_isDied)
            {
                agent.transform.position = new Vector3(
                    agent.transform.position.x, 
                    agent.transform.position.y - 0.5f, 
                    agent.transform.position.z);
                animator.SetBool("isDied", true);
                agent.speed = 0;
                _timer += Time.deltaTime;
                if (_timer >= 5)
                {
                    Destroy(gameObject);
                    SpawnerZombie.ReduceAmountZombies();
                    ZombieAliveManager.SendZombieAlive(SpawnerZombie.AmountZombies);
                }
            }
        }
    }
}
