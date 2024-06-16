using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _stop = 0;

    private Vector3 _target;

    private void Start()
    {
        _target = new Vector3(transform.position.x, transform.position.y,0);
    }

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
            _speed = _stop;
        }
        else
        {
            _speed = _speed;
            target.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);        }
    }
}
