using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class UIHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _uiHealth;

    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ChangetHealth += HealthUpdate;
    }

    private void OnDisable()
    {
        _health.ChangetHealth -= HealthUpdate;
    }

    private void HealthUpdate()
    {
        _uiHealth.text = _health.HealthSv.ToString();
    }
}
