using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public override void Enter(Hit hit)
    {
        Debug.Log("Состояние ожидания");
    }

    public override void Exit()
    {
        Debug.Log("Выход из состояния ожидания");
    }
}
