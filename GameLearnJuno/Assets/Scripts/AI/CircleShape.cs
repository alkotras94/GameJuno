using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleShape : MonoBehaviour, ISpawnShape
{
    [SerializeField] private int _radius;

    public List<Vector2> GetPositions(int count)
    {
        var points = new List<Vector2>();

        for (int i = 0; i < count; i++)
        {
            double angle = 2 * Math.PI * i / count;
            double x = _radius * Math.Cos(angle);
            double y = _radius * Math.Sin(angle);
            points.Add(new Vector2((float)x, (float)y));
        }

        return points;
    }
}
