using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Unit _unit;

    private UnitStateMachine _unitStateMachine;
    private State _currentState;
    private List<State> _states;
    private int _indexStateWaiting = 0;

    private void Awake()
    {
        _unitStateMachine = GetComponent<UnitStateMachine>();

        _states = new List<State>()
        {
            new WaitingState(),
            new MoveState(_movement, _unit, _unitStateMachine)
        };
    }

    

    public void Waiting()
    {
        _currentState = null;
        Debug.Log("Выход из текущего состояния");
    }

    public void Move()
    {
        ChangeState<MoveState>();
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
