using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;

    private Movement _movement;
    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _healthBar.Initialize(_health);
        DiSelected();
        _movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        _healthBar.Enable();
    }

    private void OnDisable()
    {
        _healthBar.Disable();
    }

    public void Selected()
    {
        _selectedGameObject.SetActive(true);
    }

    public void DiSelected()
    {
        _selectedGameObject.SetActive(false);
    }

    public void AddTarget(Vector2 target)
    {
        _movement.AddTarget(target);
    }

    
}
