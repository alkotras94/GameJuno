using System.Collections.Generic;
using UnityEngine;
using System;

public class Squad
{
    private List<Unit> _selectedUnitRtsList = new List<Unit>();
    private CircleShape _circleShape = new CircleShape();

    public void Add(IEnumerable<Unit> units)
    {
        if (units == null)
            throw new NullReferenceException();

        foreach (var unit in _selectedUnitRtsList)
        {
            unit.DiSelected();
        }

        _selectedUnitRtsList.Clear();

        foreach (var unit in units)
        {
            if (units == null)
                throw new NullReferenceException();

            unit.Selected();
            _selectedUnitRtsList.Add(unit);
        }
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
