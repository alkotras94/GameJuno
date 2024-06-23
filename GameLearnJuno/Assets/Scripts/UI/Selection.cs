using UnityEngine;
using System;
using System.Collections.Generic;

public class Selection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _selectionAreaTransform;

    public Action<Vector2, Vector2> OnMousedPosition;
    public Action<Vector2> SetPoint;

    private Vector2 StartPosition;
    private Vector2 EndPosition;

    private void Awake()
    {
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _selectionAreaTransform.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0))
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

        if (Input.GetMouseButtonUp(0))
        {
            EndPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _selectionAreaTransform.gameObject.SetActive(false);
            OnMousedPosition?.Invoke(StartPosition, EndPosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 moveToPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            SetPoint?.Invoke(moveToPosition);
        }
    }
}
