using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    private List<State> _states;
    private State _currentState;

    public Vector2 Target { get; private set; }

    public void Initialize(Movement movement, Health health)
    {
        if (movement == null)
            throw new NullReferenceException();

        if(health == null)
            throw new NullReferenceException();

        _states = new List<State>()
        {
            new WaitingState(),
            new MoveState(movement, this),
            new AttackState(health)
        };
    }

    public void Wait()
    {
        ChangeState<WaitingState>(null);
    }

    public void Move(Vector2 target)
    {
        Target = target;
        ChangeState<MoveState>(null);
    }

    public void AttackState()
    {
        ChangeState<AttackState>(null);
    }

    private void ChangeState<T>(IHit hit) where T : State
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }  

      _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter(hit);
    }
}
