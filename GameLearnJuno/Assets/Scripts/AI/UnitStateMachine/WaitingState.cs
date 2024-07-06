using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public override void Enter()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Состояние ожидания");
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }
}
