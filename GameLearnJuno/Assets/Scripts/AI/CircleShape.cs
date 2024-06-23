using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleShape
{
    private int _radius = 2;

    public List<Vector2> GetPositions(int count, Vector2 point)
    {
        var points = new List<Vector2>();

        for (int i = 0; i < count; i++)
        {
            double angle = 2 * Math.PI * i / count;
            double x = _radius * Math.Cos(angle);
            double y = _radius * Math.Sin(angle);
            points.Add(point + new Vector2((float)x, (float)y));
        }
        return points;
    }

    public List<Vector2> GetPositionListAround(Vector2 startPosition, float[] ringDistanceArray, int[] ringPositionCountArray)
    {
        List<Vector2> listPosition = new List<Vector2>();
        listPosition.Add(startPosition);

        for (int i = 0; i < ringDistanceArray.Length; i++)
        {
            listPosition.AddRange(GetPositionListAround(startPosition, ringDistanceArray[i], ringPositionCountArray[i]));
        }

        return listPosition;
    }

    private List<Vector2> GetPositionListAround(Vector2 startPosition, float distance, int positionCount)
    {
        List<Vector2> listPosition = new List<Vector2>();

        for (int i = 0; i < positionCount; i++)
        {
            float angle = i * (360f / positionCount);
            Vector2 dir = ApplyRotationVector(new Vector2(1, 0), angle);
            Vector2 position = startPosition + dir * distance;
            listPosition.Add(position);
        }

        return listPosition;
    }

    private Vector2 ApplyRotationVector(Vector2 vec, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }
}
