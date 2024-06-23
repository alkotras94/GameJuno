using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleShape : MonoBehaviour
{
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
