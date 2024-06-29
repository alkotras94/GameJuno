using System.Collections.Generic;
using UnityEngine;


//Что такое инвариант
[RequireComponent(typeof(Selection))]
public class SelectionAreaHandler : MonoBehaviour
{
    private Selection _drawingSelectionBox;
    private Squad _squad;


    private void Awake()
    {
        _drawingSelectionBox = GetComponent<Selection>();
        _squad = new Squad();
    }

    private void OnEnable()
    {
        _drawingSelectionBox.ShowedArea += UnitSelection;
        _drawingSelectionBox.ShowedPointMovement += OnMovementToShowedPoint;
    }

    private void OnDisable()
    {
        _drawingSelectionBox.ShowedArea -= UnitSelection;
        _drawingSelectionBox.ShowedPointMovement -= OnMovementToShowedPoint;
    }

    private void UnitSelection(Vector2 startPosition, Vector2 endPosition)
    {
        List<Unit> units = new List<Unit>();

        Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, endPosition);

        foreach (Collider2D collider2D in collider2DArray)
            if (collider2D.TryGetComponent(out Unit unit))
                units.Add(unit);

        _squad.Add(units);
    }

    private void OnMovementToShowedPoint(Vector2 point)
    {
        _squad.SetPointDirection(point);
    }
}
