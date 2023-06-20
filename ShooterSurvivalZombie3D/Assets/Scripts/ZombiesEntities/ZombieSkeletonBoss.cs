using UnityEngine;

namespace ZombiesEntities
{
    public class ZombieSkeletonBoss : ZombieEssence
    {
        protected override void Move()
        {
            _agent.SetDestination(playerTransform.position);

            _distance = Vector3.Distance(transform.position, playerTransform.position);
            if (_distance > attackRange)
            {
                transform.LookAt(playerTransform);
                animator.SetBool("isWalk", true);
            }
            else
            {
                animator.SetBool("isWalk", false);
                _isAttack = true;
            }
        }
        
        protected override void Attack()
        {
            if (_isAttack)
            {
                transform.LookAt(playerTransform);

                if (_distance <= attackRange)
                {
                    animator.SetBool("isAttacking", true);
                }
                else
                {
                    animator.SetBool("isAttacking", false);
                    _isAttack = false;
                }
            }
        }
    }
}
