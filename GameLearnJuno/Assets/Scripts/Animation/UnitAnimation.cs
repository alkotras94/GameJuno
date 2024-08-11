using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string CollectResources = nameof(CollectResources);
    private const string FinishCollectResources = nameof(FinishCollectResources);

    public void StartAnimationCollectResources()
    {
        _animator.SetTrigger(CollectResources);
    }

    public void FinishAnimationCollectResources()
    {
        _animator.SetTrigger(FinishCollectResources);
    }
}
