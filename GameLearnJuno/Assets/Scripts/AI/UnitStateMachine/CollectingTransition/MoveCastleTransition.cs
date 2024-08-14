using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private Transform _pointCastle;
    [SerializeField] private Movement _movement;

    private Detection _detection;
    private Hit _hitData;

    public override void Enter(Hit hitData, Detection detection)
    {
        _hitData = hitData;
        _detection = detection;
        _movement.AddTarget(_pointCastle.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Forttres resours))
        {
            Debug.Log("MoveCastleTransition");
            //_movement.StopMovement();
            _moveTransition.Enter(_hitData, _detection);
        }
    }
    public override void Exit()
    {

    }
}
