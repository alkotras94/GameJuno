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
        Debug.Log("MoveTransition");

        _hitData = hitData;
        _detection = detection;
        _detection.EnteredTrigger += OnEnteredTrigger;
        _movement.AddTarget(hitData.Target);
    }

    public override void Exit()
    {

    }

    private void OnEnteredTrigger()
    {
        _collectTransition.Enter(_hitData,_detection);
    }


}
