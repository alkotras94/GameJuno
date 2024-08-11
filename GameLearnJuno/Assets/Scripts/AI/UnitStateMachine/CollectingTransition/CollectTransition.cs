using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTransition : Transition
{
    [SerializeField] private MoveCastleTransition _moveCastleTransition;
    [SerializeField] private float _timeCollect;
    [SerializeField] private UnitAnimation _unitAnimation;


    private Hit _hitData;

    public override void Enter(Hit hitData)
    {
        _hitData = hitData;
        _unitAnimation.StartAnimationCollectResources();
        StartCoroutine(Collect());
        Debug.Log("CollectTransition");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Resours resours))
        {
            _unitAnimation.FinishAnimationCollectResources();
        }
    }
    public override void Exit()
    {

    }

    private IEnumerator Collect()
    {
        yield return new WaitForSeconds(_timeCollect);

        _moveCastleTransition.Enter(_hitData);
    }
}
