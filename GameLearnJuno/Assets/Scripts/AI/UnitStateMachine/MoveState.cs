using UnityEngine;
public class MoveState : State
{
    private Movement _movement;
    private Unit _unit;
    private UnitStateMachine _unitStateMachine;
    public MoveState(Movement movement, Unit unit, UnitStateMachine unitStateMachine)
    {
        _movement = movement;
        _unit = unit;
        _unitStateMachine = unitStateMachine;
    }

    public override void Enter()
    {
        _movement.AddTarget(_unit.Target);
        Debug.Log("Состояние движения");
    }

    public override void Exit()
    {
        Debug.Log("Выход из состояния движения");
        _unitStateMachine.OnWaiting();
    }
}
