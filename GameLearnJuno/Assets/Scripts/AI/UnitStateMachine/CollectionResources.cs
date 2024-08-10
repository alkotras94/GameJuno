using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ссылка на объект не установлена, не понимаю почему
//Не могу понять откуда выходить из состояния Сбора ресурсов
public class CollectionResources : State
{
    private UnitStateMachine _stateMachine;
    private Movement _movement;
    private Transition _transition;
    public CollectionResources(Movement movement,UnitStateMachine stateMachine, Transition transition)
    {
        _stateMachine = stateMachine;
        _movement = movement;
        _transition = transition;
    }
    public override void Enter(Hit hitData)
    {
        _transition.Enter(hitData);
    }

    public override void Exit()
    {
        
    }

}

