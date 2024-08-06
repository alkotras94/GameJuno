using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;
    [SerializeField] private UnitStateMachine _stateMachine;
    [SerializeField] private Movement _movement;

    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _healthBar.Initialize(_health);
        _stateMachine.Initialize(_movement, _health);
        Diselect();
    }

    private void OnEnable() => _healthBar.Enable();

    private void OnDisable() => _healthBar.Disable();

    public void Select() => _selectedGameObject.SetActive(true);

    public void Diselect() => _selectedGameObject.SetActive(false);

    public void AddHit(Vector2 target)
    {
        Hit hitData = new Hit(target, null);
        _stateMachine.Move(hitData);
    }

    public void TransferStateMachine(Hit hitData)
    {
        _stateMachine.CollectingResources(hitData);
    }
 
}
