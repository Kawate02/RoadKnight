public class ShieldKnock : Effect
{ 
    Vector3[] divineRange = new Vector3[8] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1), new Vector3(1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, 1), new Vector3(-1, 0, -1) };
    public ShieldKnock(int count = EffectDataBase.Effect05.count) : base(count) { id = EffectDataBase.Effect05.id;}

    public override void OnUpdate(Unit owner)
    {
        Vector3 pos = owner.pos / Constant.BlockSize;
        for (int i = 0; i < divineRange.Length; i++)
        {
            Unit u = Stage.field.GetUnit(pos + divineRange[i]);
            if (u != null && !u.IsEnemy(owner) && !u.HasEffect(new DivinProtection(owner)))
            {
                u.AddEffect(new DivinProtection(owner));
            }
        }
    }
    public override void DamageAction(Unit owner, ref int dmg)
    {
        dmg = (int)(dmg - (dmg * 0.2f));
    }
    public override void EndTurnAction(Unit owner)
    {
        count--;
        if (count <= 0) Disable(owner);
    }
}

public class DivinProtection : Effect
{
    Vector3[] divineRange = new Vector3[8] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1), new Vector3(1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, 1), new Vector3(-1, 0, -1) };
    Unit diviner;
    public DivinProtection(Unit diviner) : base() { id = EffectDataBase.Effect06.id; this.diviner = diviner; }
    public override void OnUpdate(Unit owner) 
    {
        if (diviner.hp <= 0) Disable(owner);
        bool byDiviner = false;
        for (int i = 0; i < divineRange.Length; i++)
        {
            if (Stage.field.GetUnit(owner.pos / Constant.BlockSize + divineRange[i]) == diviner)
            {
                byDiviner = true;
                break;
            }
        }
        if (!byDiviner) Disable(owner);
    }
    public override void DamageAction(Unit owner, ref int dmg)
    {
        diviner.Damage(dmg);
        dmg = 0;
    }
}