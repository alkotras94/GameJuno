using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(HealthBar))]
public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    public float HealthSv //не знаю как правильно именовать свойства, поэтому окончание Sv
    {
        get { return _health; }
    }
    public float MaxHealthSv
    {
        get { return _maxHealth; }
    }

    public event UnityAction ChangetHealth;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangetHealth?.Invoke();
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int health)
    {
        if (_health < _maxHealth)
        {
            _health += health;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
        else
        {
            _health = _maxHealth;
        }
    }

    private void OnMouseDown()
    {
        TakeDamage(1);
    }
}
