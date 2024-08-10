using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private Transition _nextTransition;
    [SerializeField] private Transform _pointCastle;
    [SerializeField] private Movement _movement;

    private Hit _hitData;
    public override void Enter(Hit hitData)
    {
        _hitData = hitData;
        _movement.AddTarget(_pointCastle.position);
        _movement.PointCame += OnCome;
    }

    public override void Exit()
    {

    }

    private void OnCome()
    {
        _movement.PointCame -= OnCome;
        _nextTransition.Enter(_hitData);
    }
}
