using System.Collections.Generic;
using UnityEngine;

public class Squad
{
    private List<Unit> _selectedUnitRtsList = new List<Unit>();
    private CircleShape _circleShape = new CircleShape();

    public void Add(Unit unit)
    {
        _selectedUnitRtsList.Add(unit);
    }

    public void Clear()
    {
        _selectedUnitRtsList.Clear();
    }

    public void SetPointDirection(Vector2 point)
    {
        List<Vector2> points = _circleShape.GetPositions(_selectedUnitRtsList.Count,point);

        for (int i = 0; i < _selectedUnitRtsList.Count; i++)
        {
            _selectedUnitRtsList[i].AddTarget(points[i]);
        }
    }

}
