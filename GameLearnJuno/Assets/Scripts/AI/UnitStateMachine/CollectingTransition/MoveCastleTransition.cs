using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private Transform _pointCastle;
    [SerializeField] private Movement _movement;
    [SerializeField] private ResourcesFortrres _resourcesFortrres;
    [SerializeField] private DetectionCastle _detectionCastle;

    private Hit _hitData;
    private int _resours = 1;

    public override void Enter(Hit hitData)
    {
        _hitData = hitData;
        _detectionCastle.Enable();
        _movement.AddTarget(_pointCastle.position);
        _detectionCastle.ExitTrigger += OnExitTrigger;
    }

    public override void Exit()
    {
        _detectionCastle.Disable();
    }

    public void OnExitTrigger()
    {
        _resourcesFortrres.AddResources(_resours);
        _detectionCastle.ExitTrigger -= OnExitTrigger;
        _moveTransition.Enter(_hitData);
    }
}
