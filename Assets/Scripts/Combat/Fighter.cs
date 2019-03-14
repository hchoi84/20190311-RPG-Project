using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField]
        private float weaponRange = 2f;
        private Transform target = default;

        private void Update()
        {
            if (target != null)
            {
                bool withinStrikeDistance = Vector3.Distance(target.position, transform.position) < weaponRange;
                if (withinStrikeDistance)
                {
                    GetComponent<Mover>().Stop();
                    Cancel();
                }
                else
                {
                    GetComponent<Mover>().MoveTo(target.position);
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
