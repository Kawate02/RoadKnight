public class Effect
{
    public int hp_buff { get; protected set; } = 0;
    public int atk_buff { get; protected set; } = 0;
    public int def_buff { get; protected set; } = 0;
    public int spd_buff { get; protected set; } = 0;
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