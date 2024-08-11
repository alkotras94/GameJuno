using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _distanceStop = 2f;

    public event Action PointCame;

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void AddTarget(Vector2 target)
    {
        _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        StartCoroutine(CalculateDistance(target));
    }

    private IEnumerator CalculateDistance(Vector2 target)
    {
        yield return new WaitUntil(() => Vector2.Distance(gameObject.transform.position, target) <= _distanceStop);
        PointCame?.Invoke();
    }
}
