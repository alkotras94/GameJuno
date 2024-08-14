using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionResources : State
{
    [SerializeField] private Transition _transition;
    [SerializeField] private Detection _detection;

    private UnitStateMachine _stateMachine;
    private Movement _movement;

    public CollectionResources(Movement movement,UnitStateMachine stateMachine, Transition transition)
    {
        _stateMachine = stateMachine;
        _movement = movement;
        _transition = transition;
    }
    public override void Enter(Hit hitData)
    {
        Debug.Log("CollectionResources");

        _detection.Enable();
        _transition.Enter(hitData, _detection);
    }

    public override void Exit()
    {
        
    }

}

