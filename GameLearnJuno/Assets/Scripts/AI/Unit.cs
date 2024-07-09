using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;
    [SerializeField] private UnitStateMachine _stateMachine;

    private Health _health;

    public Vector2 Target { get; private set; }

    public event Action CamePointed;

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

    public void AddTarget(Vector2 target)
    {
        _stateMachine.Move(target);
    }
 
}
