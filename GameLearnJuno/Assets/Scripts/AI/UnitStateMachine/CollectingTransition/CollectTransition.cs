using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTransition : Transition
{
    [SerializeField] private Transition _nextTransition;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeCollect;
    [SerializeField] private string _nameAnimationCollect;

    private Hit _hitData;

    public override void Enter(Hit hitData)
    {
        _hitData = hitData;
        _animator.SetTrigger(_nameAnimationCollect);
        StartCoroutine(TimeCollection());
    }

    public override void Exit()
    {

    }

    private IEnumerator TimeCollection()
    {
        yield return new WaitForSeconds(_timeCollect);

        _nextTransition.Enter(_hitData);
    }
}
