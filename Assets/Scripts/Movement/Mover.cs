using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
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

        public void MoveTo(Vector3 destination)
        {
            myNavMeshAgent.destination = destination;
            myNavMeshAgent.isStopped = false;
        }

        public void Stop()
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