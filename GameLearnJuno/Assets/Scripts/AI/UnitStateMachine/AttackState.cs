
public class AttackState : State
{
    private Health _health;

    public AttackState(Health health)
    {
        _health = health;
    }

    public override void Enter(IHit hit)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

}
