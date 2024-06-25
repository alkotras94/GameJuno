using UnityEngine;
using System;
using System.Collections.Generic;

public class Selection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _selectionAreaTransform;

    private State _state;
    private float _timeUpdate;

    public Action<Vector2, Vector2> OnMousedPosition;
    public Action<Vector2> SetPoint;

    private Vector2 StartPosition;
    private Vector2 EndPosition;

    private enum State
    {
        SelectionUnit,
        SetPoint
    }

    private void Awake()
    {
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            _timeUpdate += Time.deltaTime;
            if (_timeUpdate <= 0.5f)
            {
                _state = State.SetPoint;
            }
            else
            {
                _timeUpdate = 0;
                _state = State.SelectionUnit;
            }
        }

        if (Input.GetMouseButtonDown(0) || _state == State.SelectionUnit)
        {
            StartPoint();
        }else if (Input.GetMouseButton(0) || _state == State.SelectionUnit)
        {
            SelectionArea();
        }else if (Input.GetMouseButtonUp(0) || _state == State.SelectionUnit)
        {
            EndPoint();
        }

        if (Input.GetMouseButtonDown(0) || _state == State.SetPoint)
        {
            Vector2 moveToPosition = StartPosition;
            SetPoint?.Invoke(moveToPosition);
            _timeUpdate = 0;
        }
    }

    private void StartPoint()
    {
        StartPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _selectionAreaTransform.gameObject.SetActive(true);
    }

    private void SelectionArea()
    {
        Vector2 currenmousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lowerLeft = new Vector2(
                Mathf.Min(StartPosition.x, currenmousePosition.x),
                Mathf.Min(StartPosition.y, currenmousePosition.y)
            );

        Vector2 upperRight = new Vector2(
                Mathf.Max(StartPosition.x, currenmousePosition.x),
                Mathf.Max(StartPosition.y, currenmousePosition.y)
            );

        _selectionAreaTransform.position = lowerLeft;
        _selectionAreaTransform.localScale = upperRight - lowerLeft;
    }

    private void EndPoint()
    {
        EndPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _selectionAreaTransform.gameObject.SetActive(false);
        OnMousedPosition?.Invoke(StartPosition, EndPosition);
    }
}
