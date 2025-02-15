public class AttackDebuff : Effect
{
    public AttackDebuff(int count = EffectDataBase.Effect03.count) : base(count) { id = EffectDataBase.Effect03.id; }
    public override void Init(Unit owner)
    {
        base.Init(owner);
        atk_buff = EffectDataBase.Effect03.attack_magnification;
    }
    public override void EndTurnAction(Unit owner)
    {
        count--;
        if (count <= 0) Disable(owner);
    }
}

public class DefenceDebuff : Effect
{
    public DefenceDebuff(int count = EffectDataBase.Effect04.count) : base(count) { id = EffectDataBase.Effect04.id; }
    public override void Init(Unit owner)
    {
        base.Init(owner);
        def_buff = EffectDataBase.Effect04.defence_magnification;
    }
    public override void EndTurnAction(Unit owner)
    {
        count--;
        if (count <= 0) Disable(owner);
    }
}