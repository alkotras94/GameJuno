using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resours : MonoBehaviour, IHit
{
    [SerializeField] protected int _resources = 1000;

    public Vector2 Target { get; set; }

    public void Disable()
    {
        throw new System.NotImplementedException();
    }

    public void Enable()
    {
        throw new System.NotImplementedException();
    }

    protected void Add(int resources)
    {
        _resources += resources;
    }

    protected void Take(int value)
    {
        _resources -= value;
    }
}
