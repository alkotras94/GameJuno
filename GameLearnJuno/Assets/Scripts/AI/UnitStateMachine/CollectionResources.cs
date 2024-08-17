using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionResources : State
{
    private Transition _transition;
    private Detection _detection;
    private UnitStateMachine _stateMachine;
    private Movement _movement;

    public CollectionResources(Movement movement,UnitStateMachine stateMachine, Transition transition, Detection detection)
    {
        _stateMachine = stateMachine;
        _movement = movement;
        _transition = transition;
        _detection = detection;
    }
    public override void Enter(Hit hitData)
    {
        _detection.Enable();
        _transition.Enter(hitData, _detection);
    }

    public override void Exit()
    {
        _transition.Exit();
    }

    public void OutState()
    {
        _stateMachine.Wait();
    }

}

