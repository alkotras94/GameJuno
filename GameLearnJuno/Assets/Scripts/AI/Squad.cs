using System.Collections.Generic;
using UnityEngine;
using System;

public class Squad : IHitResources
{
    private List<Unit> _selectedUnitRtsList = new List<Unit>();
    private CircleShape _circleShape = new CircleShape();

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

    public void AddTarget(Vector2 point)
    {
        List<Vector2> points = SetPoinDirection(point);

        for (int i = 0; i < _selectedUnitRtsList.Count; i++)
        {
            _selectedUnitRtsList[i].AddHit(points[i]);
        }
    }

    public List<Vector2> SetPoinDirection(Vector2 point)
    {
        List<Vector2> points = _circleShape.GetPositionListAround(point, _selectedUnitRtsList.Count);

        return points;
    }

    public void Visit(Resours resources)
    {
        Visit((dynamic)resources);
    }

    public void Visit(Stone stoneHit)
    {
        
    }

    public void Visit(Wood woodHit)
    {
        
    }
}

public interface IHitResources
{
    void Visit(Resours resources);
    void Visit(Stone stoneHit);
    void Visit(Wood woodHit);
}
