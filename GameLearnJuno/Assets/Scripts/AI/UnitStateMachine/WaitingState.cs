using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public override void Enter(IHit hit)
    {
        Debug.Log("��������� ��������");
    }

    public override void Exit()
    {
        Debug.Log("����� �� ��������� ��������");
    }
}
