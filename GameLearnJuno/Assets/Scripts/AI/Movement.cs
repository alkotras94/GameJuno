using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private Vector2 _target;

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void AddTarget(Vector2 target)
    {
        _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
