using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawingSelectionBox : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _selectionAreaTransform;

    public Vector3 StartPosition { get; private set; }
    public Vector3 EndPosition { get; private set; }

    public Action<Vector3,Vector3> OnMousedPosition;
    public Action<Vector3> SetPoint;

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
            Vector3 currenmousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 lowerLeft = new Vector3(
                    Mathf.Min(StartPosition.x, currenmousePosition.x),
                    Mathf.Min(StartPosition.y, currenmousePosition.y)
                );

            Vector3 upperRight = new Vector3(
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
            Vector3 moveToPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            SetPoint?.Invoke(moveToPosition);
        }
    }
}
