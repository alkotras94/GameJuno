using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private Movement _movement;
    private Unit _unit;
    public MoveState(Movement movement, Unit unit)
    {
        _movement = movement;
        _unit = unit;
    }
    public override void Enter()
    {
        _movement.AddTarget(_unit.Target);
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }
}
