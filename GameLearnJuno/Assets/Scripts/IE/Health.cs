using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UIHealth))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public int HealthSv
    {
        get { return _health; }
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
}
