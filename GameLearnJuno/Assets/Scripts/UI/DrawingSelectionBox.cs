using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Как передавать параметры через событие?
public class DrawingSelectionBox : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _selectionAreaTransform;

    public Vector3 StartPosition { get; private set; }
    public Vector3 EndPosition { get; private set; }

    public Action OnMousedStart;
    public Action OnMousedEnd;

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
            OnMousedStart?.Invoke();
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
            OnMousedEnd?.Invoke();
        }
    }
}
