using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Unit _unit;

    private UnitStateMachine _unitStateMachine;
    private List<State> _states;
    private State _currentState;

    private void Awake()
    {
        _unitStateMachine = GetComponent<UnitStateMachine>();

        _states = new List<State>()
        {
            new WaitingState(),
            new MoveState(_movement, _unit, _unitStateMachine),
            new AttackState()
        };
    }

    private void OnEnable()
    {
        _unit.CamePointed += OnWaiting;
        _unit.EnableStateMoving += OnMove;
    }

    private void OnDisable()
    {
        _unit.CamePointed -= OnWaiting;
        _unit.EnableStateMoving -= OnMove;
    }

    public void OnWaiting()
    {
        _currentState = null;
        ChangeState<WaitingState>();
    }

    public void OnMove()
    {
        ChangeState<MoveState>();
    }

    public void OnAttackState()
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
