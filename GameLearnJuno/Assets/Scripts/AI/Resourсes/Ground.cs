using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Hit
{
    public Vector2 Target { get; set; }

    public void Disable()
    {
        throw new System.NotImplementedException();
    }

    public void Enable()
    {
        Target = Input.mousePosition;
    }
}
