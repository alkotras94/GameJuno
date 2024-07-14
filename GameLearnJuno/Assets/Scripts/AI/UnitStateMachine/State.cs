using UnityEngine;

public abstract class State
{
    public abstract void Enter(Hit hit);

    public abstract void Exit();

    protected bool TryConvert<T>(Hit hit, out T concretHit) where T : class
    {
        concretHit = hit as T;

        return concretHit != null;
    }
}
