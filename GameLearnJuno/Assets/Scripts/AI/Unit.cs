using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;
    [SerializeField] private UnitStateMachine _unitStateMachine;

    public Vector2 Target { get; private set; }
    //private Movement _movement;
    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _healthBar.Initialize(_health);
        DiSelect();
        //_movement = GetComponent<Movement>();
        _unitStateMachine = GetComponent<UnitStateMachine>();
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
        float distane = Vector2.Distance(gameObject.transform.position, Target);

        //Debug.Log(distane);

        if (distane <= 0.5f)
        {
            _unitStateMachine.Waiting();
        }
    }
    public void AddTarget(Vector2 target)
    {
        Target = target;
        //_movement.AddTarget(target);
        _unitStateMachine.Move();
    }
 
}
