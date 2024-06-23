using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _stop = 0;

    private Vector2 _target;

    private void Start()
    {
        _target = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        ToMove(_target);
    }

    public void AddTarget(Vector2 target)
    {
        _target = target;
    }

    private void ToMove(Vector2 target)
    {
        if (target == null)
        {
            _speed = _stop;
        }
        else
        {
            _speed = _speed;
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * _speed);
        }
    }
}
