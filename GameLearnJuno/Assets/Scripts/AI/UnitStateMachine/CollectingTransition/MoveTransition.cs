using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private CollectTransition _collectTransition;
    [SerializeField] private Movement _movement;

    private Detection _detection;
    private Hit _hitData;

    public override void Enter(Hit hitData, Detection detection)
    {
        _hitData = hitData;
        _detection = detection;
        _movement.AddTarget(hitData.Target);
        _detection.EnteredTrigger += OnEnteredTrigger;
    }

    public override void Exit()
    {
        _detection.Disable();
        _collectTransition.Exit();
    }

    private void OnEnteredTrigger()
    {
        _collectTransition.Enter(_hitData,_detection);
        _detection.EnteredTrigger -= OnEnteredTrigger;
    }


}
