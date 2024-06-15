using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRTSController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _selectionAreaTransform;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private List<Unit> _selectedUnitRtsList;

    private void Awake()
    {
        _selectedUnitRtsList = new List<Unit>();
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currenmousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 lowerLeft = new Vector3(
                    Mathf.Min(_startPosition.x, currenmousePosition.x),
                    Mathf.Min(_startPosition.y, currenmousePosition.y)
                );

            Vector3 upperRight = new Vector3(
                    Mathf.Max(_startPosition.x, currenmousePosition.x),
                    Mathf.Max(_startPosition.y, currenmousePosition.y)
                );

            _selectionAreaTransform.position = lowerLeft;
            _selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        _endPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            _selectionAreaTransform.gameObject.SetActive(true);
            _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(_startPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _selectionAreaTransform.gameObject.SetActive(false);
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(_startPosition, _endPosition);

            foreach (Unit unit in _selectedUnitRtsList)
            {
                unit.SetSelctedVisible(false);
            }

            _selectedUnitRtsList.Clear();

            foreach (Collider2D collider2D in collider2DArray)
            {
                Unit unit = collider2D.GetComponent<Unit>();

                if (unit != null)
                {
                    _selectedUnitRtsList.Add(unit);
                    unit.SetSelctedVisible(true);
                }

                Debug.Log(_selectedUnitRtsList.Count);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 moveToPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            foreach (Unit unit in _selectedUnitRtsList)
            {
                unit.gameObject.GetComponent<Moving>().AddTarget(moveToPosition);
            }
        }
    }
}
