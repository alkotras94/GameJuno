using System.Collections.Generic;
using UnityEngine;
using System;

public class Squad
{
    private List<Unit> _selectedUnitRtsList = new List<Unit>();
    private CircleShape _circleShape = new CircleShape();
    private Selection _selection;

    public Squad(Selection selection)
    {
        _selection = selection;
        _selection.ShowedPointMovement += OnHandleHit;
    }
    public void Add(IEnumerable<Unit> units)
    {
        if (units == null)
            throw new NullReferenceException();

        foreach (var unit in _selectedUnitRtsList)
        {
            unit.Diselect();
        }

        _selectedUnitRtsList.Clear();

        foreach (var unit in units)
        {
            if (units == null)
                throw new NullReferenceException();

            unit.Select();
            _selectedUnitRtsList.Add(unit);
        }
    }

    public void OnHandleHit(Hit hit)
    {
        List<Vector2> points = SetPoinDirection(hit.Target);

        for (int i = 0; i < _selectedUnitRtsList.Count; i++)
        {
            _selectedUnitRtsList[i].AddHit(hit);
        }

        _selection.ShowedPointMovement -= OnHandleHit;
    }

    public List<Vector2> SetPoinDirection(Vector2 point)
    {
        List<Vector2> points = _circleShape.GetPositionListAround(point, _selectedUnitRtsList.Count);

        return points;
    }

}
