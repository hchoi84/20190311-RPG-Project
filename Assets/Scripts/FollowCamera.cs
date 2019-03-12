using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target = default;

    private void Update()
    {
        transform.position = target.position;
    }
}
