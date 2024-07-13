using UnityEngine;
using System;
using System.Collections;

//Колайдер земли перекрывает все остальные коллайдеры
public class Selection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _selectionAreaTransform;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;
    [SerializeField] private float _timerForSelection;

    private State _currentState;
    private Coroutine _coroutine;

    public event Action<Vector2, Vector2> ShowedArea;
    public event Action<IHit,Vector2> ShowedPointMovement;

    private void Awake()
    {
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPoint();
        }

        if (Input.GetMouseButton(0))
        {
            DrowSelectionArea();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_currentState == State.SelectionUnits)
                EndPoint();
            else
                Raycast();
        }
    }

    private void Raycast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);


        if (hit.collider.TryGetComponent<IHit>(out IHit iHit))
        {
            Debug.Log(hit.point);
            ShowedPointMovement?.Invoke(iHit, hit.point);
        }
    }
    private void StartPoint()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _currentState = State.SelectionUnits;

        _coroutine = StartCoroutine(StartTimer());

        _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _selectionAreaTransform.gameObject.SetActive(true);
    }

    private void DrowSelectionArea()
    {
        _endPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lowerLeft = new Vector2(
                Mathf.Min(_startPosition.x, _endPosition.x),
                Mathf.Min(_startPosition.y, _endPosition.y)
            );

        Vector2 upperRight = new Vector2(
                Mathf.Max(_startPosition.x, _endPosition.x),
                Mathf.Max(_startPosition.y, _endPosition.y)
            );

        _selectionAreaTransform.position = lowerLeft;
        _selectionAreaTransform.localScale = upperRight - lowerLeft;

        if (_currentState == State.SelectionUnits)
            ShowedArea?.Invoke(_startPosition, _endPosition);
    }

    private void EndPoint()
    {
        _endPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _selectionAreaTransform.gameObject.SetActive(false);
        ShowedArea?.Invoke(_startPosition, _endPosition);
    }

    private IEnumerator StartTimer()
    {
        _currentState = State.SetPoint;

        yield return new WaitForSeconds(_timerForSelection);

        _currentState = State.SelectionUnits;
    }

    private enum State
    {
        SelectionUnits,
        SetPoint
    }
}
