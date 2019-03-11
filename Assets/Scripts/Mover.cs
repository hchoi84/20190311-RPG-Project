using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private NavMeshAgent myNavMeshAgent = default;

    void Update()
    {
        myNavMeshAgent.destination = target.position;
    }
}
