﻿using UnityEngine;
using RPG.Core;
using RPG.Movement;

namespace RPG.Combat
{
    //Note that you can inherent from many interfaces
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField]
        private float weaponRange = 2f;
        [SerializeField]
        private float timeBetweenAttacks = 1f;
        [SerializeField]
        private float weaponDamage = 60f;

        private Transform target = default;
        private float timeSinceLastAttack = 0f;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target != null && !GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (target.GetComponent<Health>().isCharDead()) { Cancel(); return; }
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //This will trigger Hit() via Animation
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
            }
        }

        //Animation event
        private void Hit()
        {
            target.GetComponent<Health>().TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(target.position, transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
