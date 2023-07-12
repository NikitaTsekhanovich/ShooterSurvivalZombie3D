using UnityEngine;

namespace ZombiesEntities
{
    public class ZombieParasite : ZombieEssence
    {
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
        }
        
        protected override void Attack()
        {
            if (isAttack)
            {
                transform.LookAt(playerTransform);

                if (distance <= attackRange)
                {
                    animator.SetBool("isAttacking", true);
                }
                else
                {
                    animator.SetBool("isAttacking", false);
                    isAttack = false;
                }
            }
        }
    }
}
