using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.ChangetHealth += HealthUpdate;
    }

    private void OnEnable() // не подписывается на событие, выходит ошибка 
    {
        //_health.ChangetHealth += HealthUpdate;
    }

    private void OnDisable()
    {
        _health.ChangetHealth -= HealthUpdate;
    }

    private void HealthUpdate()
    {
        _slider.value = _health.HealthSv / _health.MaxHealthSv;
    }
}
