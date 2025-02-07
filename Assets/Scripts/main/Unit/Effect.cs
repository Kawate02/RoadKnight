public class Effect
{
    public float hp_buff { get; protected set; } = 0;
    public float atk_buff { get; protected set; } = 0;
    public float def_buff { get; protected set; } = 0;
    public float spd_buff { get; protected set; } = 0;
    public int move_range_buff { get; protected set; } = 0;
    public virtual void Init(Unit owner) {}
    public virtual void Disable(Unit owner) {}
    public virtual void StartTurnAction(Unit owner) {}
    public virtual void EndTurnAction(Unit owner) {}
    public virtual void MoveAction(Unit owner) {}
    public virtual void AttackAction(Unit owner, Unit tardet) {}
    public virtual void DamageAction(Unit owner, float dmg) {}
    public virtual void DeadAction(Unit owner) {}
}