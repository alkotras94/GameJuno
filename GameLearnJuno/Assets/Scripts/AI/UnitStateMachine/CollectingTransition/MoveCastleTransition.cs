using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private Transform _pointCastle;
    [SerializeField] private Movement _movement;

    private Hit _hitData;
    public override void Enter(Hit hitData)
    {
        _hitData = hitData;
        _movement.AddTarget(_pointCastle.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Вошли в колайдер");
        if (collision.gameObject.TryGetComponent(out Forttres resours))
        {
            Debug.Log("MoveCastleTransition");
            //_movement.StopMovement();
            _moveTransition.Enter(_hitData);
        }
    }
    public override void Exit()
    {

    }
}
