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

    private Detection _detection;
    private Hit _hitData;
    private CollectionResources _collectionResources;
    private int _resours = 1;

    public override void Enter(Hit hitData, Detection detection)
    {
        _hitData = hitData;
        _detection = detection;
        _movement.AddTarget(_pointCastle.position);
        _detection.OutTrigger += OnOutTrigger;
    }

    public override void Exit()
    {
        _collectionResources.OutState();
    }

    public void OnOutTrigger()
    {
        _resourcesFortrres.AddResources(_resours);
        _moveTransition.Enter(_hitData, _detection);
        _detection.OutTrigger -= OnOutTrigger;
    }
}
