using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private CollectTransition _collectTransition;
    [SerializeField] private Movement _movement;

    private Hit _hitData;
    public override void Enter(Hit hitData)
    {
        Debug.Log("MoveTransition");
        _hitData = hitData;
        _movement.AddTarget(hitData.Target);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Вошли в колайдер");
        if (collision.gameObject.TryGetComponent(out Resours resours))
        {
            Debug.Log("Вошли в колайдер ресурса");
            _collectTransition.Enter(_hitData);
            //_movement.StopMovement();
        }
    }

    public override void Exit()
    {

    }
}
