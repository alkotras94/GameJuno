using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHit
{
    public Vector2 Target { get; set; }
    public void Enable();
    public void Disable();
}
