using System.Data.Common;

public class AttackBuff : Effect
{
    public AttackBuff(int count = EffectDataBase.Effect01.count) : base(count) { id = EffectDataBase.Effect01.id; }
    public override void Init(Unit owner)
    {
        base.Init(owner);
        atk_buff = EffectDataBase.Effect01.attack_magnification;
    }
    public override void EndTurnAction(Unit owner)
    {
        count--;
        if (count <= 0) Disable(owner);
    }
}

public class DefenceBuff : Effect
{
    public DefenceBuff(int count = EffectDataBase.Effect02.count) : base(count) { id = EffectDataBase.Effect02.id; }
    public override void Init(Unit owner)
    {
        base.Init(owner);
        def_buff = EffectDataBase.Effect02.defence_magnification;
    }
    public override void EndTurnAction(Unit owner)
    {
        count--;
        if (count <= 0) Disable(owner);
    }
}