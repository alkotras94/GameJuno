using UnityEngine;

public class Hit 
{
    public Vector2 Target { get; private set; }
    public IHitble Hitble { get; private set; }

    public Hit(Vector2 target, IHitble hitble)
    {
        Target = target;
        Hitble = hitble;
    }
}
