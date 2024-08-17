using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTransition : Transition
{
    [SerializeField] private MoveCastleTransition _moveCastleTransition;
    [SerializeField] private float _timeCollect;
    [SerializeField] private UnitAnimation _unitAnimation;


    private Hit _hitData;
    private Detection _detection;

    public override void Enter(Hit hitData, Detection detection)
    {
        _hitData = hitData;
        _detection = detection;
        StartCoroutine(Collect());
    }
    public override void Exit()
    {
        _moveCastleTransition.Exit();
    }

    private IEnumerator Collect()
    {
        _unitAnimation.StartAnimationCollectResources();

        yield return new WaitForSeconds(_timeCollect);

        _unitAnimation.FinishAnimationCollectResources();
        _moveCastleTransition.Enter(_hitData, _detection);
    }
}
