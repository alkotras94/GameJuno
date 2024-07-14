using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hit : MonoBehaviour
{
    public Vector2 Target { get; private set; }

    public void Add(Vector2 target)
    {
        Target = target;
    }
}
