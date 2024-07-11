using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    private Movement _movement;
    private List<State> _states;
    private State _currentState;

    public Vector2 Target { get; private set; }

    public void Initialize(Movement movement)
    {
        if (movement == null)
            Debug.Log("Movement null");

        _movement = movement;

        _states = new List<State>()
        {
            new WaitingState(),
            new MoveState(_movement, this),
            new AttackState()
        };
    }

    public void Wait()
    {
        ChangeState<WaitingState>();
    }

    public void Move(Vector2 target)
    {
        Target = target;
        ChangeState<MoveState>();
    }

    public void AttackState()
    {
        ChangeState<AttackState>();
    }

    private void ChangeState<T>() where T : State
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }  

        _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter();
    }
}
