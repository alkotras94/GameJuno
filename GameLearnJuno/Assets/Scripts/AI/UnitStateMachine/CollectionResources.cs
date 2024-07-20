using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionResources : State, IHitResources
{
    private UnitStateMachine _stateMachine;
    private Movement _movement;
    public CollectionResources(Movement movement,UnitStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _movement = movement;
    }
    public override void Enter(Vector2 point, Resours resours)
    {
        Visit(resours);
    }

    public override void Exit()
    {
        
    }

    public void Visit(Resours resources)
    {
        Visit((dynamic)resources);
    }

    public void Visit(Stone stoneHit)
    {

    }

    public void Visit(Wood woodHit)
    {

    }
}

public interface IHitResources
{
    void Visit(Resours resources);
    void Visit(Stone stoneHit);
    void Visit(Wood woodHit);
}
