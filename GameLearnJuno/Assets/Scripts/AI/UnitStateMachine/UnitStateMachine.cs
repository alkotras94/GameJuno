using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    private List<State> _states;
    private State _currentState;

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
            new AttackState(health),
            new CollectionResources(movement,this)
        };
    }

    public void Wait()
    {
        ChangeState<WaitingState>(Vector2.zero, null);
    }

    public void Move(Vector2 point)
    {
        ChangeState<MoveState>(point, null);
    }

    public void AttackState(Vector2 point)
    {
        ChangeState<AttackState>(point, null);
    }

    public void CollectingResources(Vector2 point, Resours resours)
    {
        ChangeState<CollectionResources>(point, resours);
    }

    private void ChangeState<T>(Vector2 point, Resours resours) where T : State
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }  

        _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter(point, resours);
    }
}

