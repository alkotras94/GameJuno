using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;

    public event Action CamePointed;
    public event Action EnableStateMoving;
    public Vector2 Target { get; private set; }

    private Health _health;
    private bool _onPoints = true;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _healthBar.Initialize(_health);
        DiSelect();
    }

    private void OnEnable()
    {
        _healthBar.Enable();
    }

    private void OnDisable()
    {
        _healthBar.Disable();
    }

    public void Select()
    {
        _selectedGameObject.SetActive(true);
    }

    public void DiSelect()
    {
        _selectedGameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Vector2.Distance(gameObject.transform.position, Target) <= 0.5f && _onPoints)
        {
            CamePointed?.Invoke();
            _onPoints = false;
        }
    }
    public void AddTarget(Vector2 target)
    {
        _onPoints = true;
        Target = target;
        EnableStateMoving?.Invoke();
    }
 
}
