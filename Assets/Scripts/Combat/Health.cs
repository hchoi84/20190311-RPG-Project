using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float healthPoints = 100f;
        private bool isDead = false;

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) { return; }
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }

        public bool isCharDead()
        {
            return isDead;
        }
    }
}