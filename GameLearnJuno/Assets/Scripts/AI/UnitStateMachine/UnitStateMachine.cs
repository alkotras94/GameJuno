using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Unit _unit;

    private State _currentState;
    private List<State> _states;

    private void Awake()
    {
        _states = new List<State>()
        {
            new WaitingState(),
            new MoveState(_movement, _unit)
        };
    }

    public void Waiting()
    {
        ChangeState<WaitingState>();
    }

    public void Move()
    {
        ChangeState<MoveState>();
    }

    private void ChangeState<T>() where T : State
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter();
    }

}
