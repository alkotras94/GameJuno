using UnityEngine;

[RequireComponent(typeof(Moving))]
public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    private GameObject _selectedGameObject;

    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _healthBar.Initialize(_health);
        _selectedGameObject = transform.Find("Selected").gameObject;
        SetSelctedVisible(false);
    }

    public void SetSelctedVisible(bool visible)
    {
        _selectedGameObject.SetActive(visible);
    }

    private void OnEnable()
    {
        _healthBar.Enable();
    }

    private void OnDisable()
    {
        _healthBar.Disable();
    }

}
