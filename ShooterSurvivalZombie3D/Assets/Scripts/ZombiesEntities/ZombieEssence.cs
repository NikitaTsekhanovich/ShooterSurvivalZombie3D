using Managers;
using Player.MainPlayer;
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
        protected float _distance;
        protected NavMeshAgent _agent;
        protected bool _isAttack;
        private bool _isDied;
        private float _timer;
        protected Transform playerTransform;
        
        public int Damage => damage;
        
        private void Start()
        {
            playerTransform = Player.MainPlayer.Player.PlayerSingleton.transform;
            animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
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
                _agent.transform.position = new Vector3(
                    _agent.transform.position.x, 
                    _agent.transform.position.y - 0.5f, 
                    _agent.transform.position.z);
                animator.SetBool("isDied", true);
                _agent.speed = 0;
                _timer += Time.deltaTime;
                if (_timer >= 5)
                {
                    Destroy(gameObject);
                    WaveLoadManager.AmountZombies -= 1;
                    ZombieAliveManager.SendZombieAlive(WaveLoadManager.AmountZombies);
                }
            }
        }
    }
}
