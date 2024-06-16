using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;


    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _healthBar.Initialize(_health);
        DisableSelected();
    }

    public void EnableSelected()
    {
        _selectedGameObject.SetActive(true);
    }

    public void DisableSelected()
    {
        _selectedGameObject.SetActive(false);
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
