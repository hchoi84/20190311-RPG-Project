using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    //Note that you can inherent from many interfaces
    public class Mover : MonoBehaviour, IAction
    {
        private NavMeshAgent myNavMeshAgent = default;

        private void Start()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            myNavMeshAgent.destination = destination;
            myNavMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            myNavMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = myNavMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = Mathf.Abs(localVelocity.z);
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}