using System;
using UnityEngine;
public class MoveState : State
{
    private Movement _movement;
    private UnitStateMachine _stateMachine;
    public MoveState(Movement movement, UnitStateMachine unitStateMachine)
    {
        _movement = movement;
        _stateMachine = unitStateMachine;
    }

    public override void Enter()
    {
        _movement.AddTarget(_stateMachine.Target);
        _movement.PointCame += OnPointCame;
        Debug.Log("��������� ��������");
    }

    public override void Exit()
    {
        _movement.PointCame -= OnPointCame;
        Debug.Log("����� �� ��������� ��������");
    }

    private void OnPointCame()
    {
        _stateMachine.Wait();
    }
}
