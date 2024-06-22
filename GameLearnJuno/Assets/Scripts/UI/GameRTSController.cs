using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DrawingSelectionBox))]
public class GameRTSController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
 
    private List<Unit> _selectedUnitRtsList;
    private DrawingSelectionBox _drawingSelectionBox;

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

    private void SetPointDirection(Vector3 point)
    {
        foreach (Unit unit in _selectedUnitRtsList)
        {
            unit.GetComponent<Movement>().AddTarget(point);
        }
    }
}
