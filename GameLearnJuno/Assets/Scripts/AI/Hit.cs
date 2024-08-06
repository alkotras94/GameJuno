using UnityEngine;

public class Hit 
{
    public Vector2 Target { get; private set; }
    public Resours Resours { get; private set; }

    public Hit(Vector2 target, Resours resours)
    {
        Target = target;
        Resours = resours;
    }
}
