using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour, IHitVisitor
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

    public void Visit(Hit hit)
    {
        Visit((dynamic)hit);
    }

    public void Visit(Ground groundHit)
    {
        Debug.Log("Земля");
        OnHandleHit(groundHit);
    }

    public void Visit(Wood woodHit)
    {
        Debug.Log("Дерево");
        OnHandleHit(woodHit);
    }

    public void Visit(Stone stoneHit)
    {
        Debug.Log("Камень");
        OnHandleHit(stoneHit);
    }

    public void Wait()
    {
        ChangeState<WaitingState>(null);
    }

    public void OnHandleHit(Hit hit)
    {
        ChangeState<MoveState>(null);
    }

    public void AttackState()
    {
        ChangeState<AttackState>(null);
    }

    private void ChangeState<T>(Hit hit) where T : State
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }  

      _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter(hit);
    }
}

public interface IHitVisitor
{
    void Visit(Hit hit);
    void Visit(Ground groundHit);
    void Visit(Wood woodHit);
    void Visit(Stone stoneHit);
}
