using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Selection))]
public class SelectionAreaHandler : MonoBehaviour
{
    private List<Unit> _selectedUnitRtsList;
    private Selection _drawingSelectionBox;
    private Squad _squad;


    private void Awake()
    {
        _selectedUnitRtsList = new List<Unit>();
        _drawingSelectionBox = GetComponent<Selection>();
        _squad = new Squad();
    }

    private void OnEnable()
    {
        _drawingSelectionBox.OnMousedPosition += UnitSelection;
        _drawingSelectionBox.SetPoint += SetPointUnit;
    }

    private void OnDisable()
    {
        _drawingSelectionBox.OnMousedPosition -= UnitSelection;
        _drawingSelectionBox.SetPoint -= SetPointUnit;
    }

    private void UnitSelection(Vector2 startPosition, Vector2 endPosition)
    {
        Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, endPosition);

        foreach (Unit unit in _selectedUnitRtsList)
            unit.DisableSelected();

        _selectedUnitRtsList.Clear();
        _squad.Clear();

        foreach (Collider2D collider2D in collider2DArray)
        {
            //bool unit = collider2D.TryGetComponent(out Unit unit);

            if (collider2D.TryGetComponent(out Unit unit))
            {
                _squad.Add(unit);
                _selectedUnitRtsList.Add(unit);
                unit.EnableSelected();
            }

            Debug.Log(_selectedUnitRtsList.Count);
        }
    }

    private void SetPointUnit(Vector2 point)
    {
        _squad.SetPointDirection(point);
    }
}
