using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DrawingSelectionBox))]
public class GameRTSController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
 
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private List<Unit> _selectedUnitRtsList;
    private DrawingSelectionBox _drawingSelectionBox;

    private void Awake()
    {
        _selectedUnitRtsList = new List<Unit>();
        _drawingSelectionBox = GetComponent<DrawingSelectionBox>();
    }

    private void OnEnable()
    {
        _drawingSelectionBox.OnMousedStart += AddStartVector;
        _drawingSelectionBox.OnMousedEnd += AddEndVector;
    }

    private void OnDisable()
    {
        _drawingSelectionBox.OnMousedStart -= AddStartVector;
        _drawingSelectionBox.OnMousedEnd -= AddEndVector;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(_startPosition, _endPosition);

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

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 moveToPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            foreach (Unit unit in _selectedUnitRtsList)
            {
                unit.GetComponent<Movement>().AddTarget(moveToPosition);
            }
        }
    }

    private void AddStartVector()
    {
        _startPosition = _drawingSelectionBox.StartPosition;
    }

    private void AddEndVector()
    {
        _endPosition = _drawingSelectionBox.EndPosition;
    }
}
