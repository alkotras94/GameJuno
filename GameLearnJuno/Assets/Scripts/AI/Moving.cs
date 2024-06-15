using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private Vector3 _target;

    private void Update()
    {
        ToMove(_target);
    }

    public void AddTarget(Vector3 target)
    {
        _target = target;
    }

    private void ToMove(Vector3 target)
    {
        if (target == null)
        {
            _speed = 0;
        }
        else
        {
            _speed = 1;
            target.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);
            
        }
    }
}
