using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(DrawingSelectionBox))]
public class Squad : MonoBehaviour
{
    private List<Unit> _selectedUnitRtsList;
    private DrawingSelectionBox _drawingSelectionBox;
    private CircleShape _circleShape = new CircleShape();


    private void Awake()
    {
        _selectedUnitRtsList = new List<Unit>();
        _drawingSelectionBox = GetComponent<DrawingSelectionBox>();
    }

    private void OnEnable()
    {
        _drawingSelectionBox.OnMousedPosition += UnitSelection;
        _drawingSelectionBox.SetPoint += SetPointDirection;
    }

    private void OnDisable()
    {
        _drawingSelectionBox.OnMousedPosition -= UnitSelection;
        _drawingSelectionBox.SetPoint -= SetPointDirection;
    }

    private void UnitSelection(Vector3 startPosition, Vector3 endPosition)
    {
        Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, endPosition);

        foreach (Unit unit in _selectedUnitRtsList)
        {
            unit.DisableSelected();
        }

        _selectedUnitRtsList.Clear();

        foreach (Collider2D collider2D in collider2DArray)
        {
            Unit unit = collider2D.GetComponent<Unit>();

            if (unit != null)
            {
                _selectedUnitRtsList.Add(unit);
                unit.EnableSelected();
            }

            Debug.Log(_selectedUnitRtsList.Count);
        }
    }


    private void SetPointDirection(Vector2 point)
    {
        List<Vector2> points = _circleShape.GetPositionListAround(point, new float[] { 2f, 4f, 6f }, new int[] {5,10,15});

        for (int i = 0; i < _selectedUnitRtsList.Count; i++)
        {
            _selectedUnitRtsList[i].AddTarget(points[i]);
        }
    }

}
