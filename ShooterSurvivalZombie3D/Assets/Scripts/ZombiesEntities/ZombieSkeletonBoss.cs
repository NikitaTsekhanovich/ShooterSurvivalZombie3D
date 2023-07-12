using UnityEngine;

namespace ZombiesEntities
{
    public class ZombieSkeletonBoss : ZombieEssence
    {
        [SerializeField] private AudioSource loudScreamZombieSound;
        private bool _isDash;
        private bool _isScream;
        
        protected override void Move()
        {
            agent.SetDestination(playerTransform.position);

            distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance > attackRange)
            {
                transform.LookAt(playerTransform);
                animator.SetBool("isWalk", true);
            }
            else
            {
                animator.SetBool("isWalk", false);
                isAttack = true;
            }

            Scream();
            Dash();
        }

        private void Dash()
        {
            if (_isDash)
            {
                if (Time.time % 5 >= 1)
                {
                    agent.speed = 3.9f;
                }
                else
                {
                    _isDash = false;
                    agent.speed = 1;
                }
            }
        }

        private void Scream()
        {
            if (Time.time % 20 >= 19)
            {
                animator.Play("Scream");
                _isScream = true;
                agent.speed = 0;
                loudScreamZombieSound.Play();
            }
            
            if (_isScream)
            {
                var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if (!animatorStateInfo.IsName("Scream"))
                {
                    _isDash = true;
                    _isScream = false;
                }
            }
        }
    }
}
