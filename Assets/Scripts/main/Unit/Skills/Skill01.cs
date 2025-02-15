using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill01 : SkillBase
{
    public override SkillBase Init()
    {
        _range = SkillDataBase.Skill01.Range;
        return this;
    }
    protected override async Task AreaCal(Vector3 pos = null) 
    {
        await base.AreaCal();
        for (int i = 0; i < base.range.Count; i++)
        {
            AddPos(range[i]);
        }
        Stage.skillArea.Enable(Path.UI_Attack_Area);
    }
    public async override void Exe(Vector3 pos)
    {
        await Stage.skillArea.Destroy();
        var unit = GetUnits(pos);
        if (unit != null && unit.IsEnemy(owner)) unit.Damage(Formula.Damage(owner.atk, unit.def, SkillDataBase.Skill01.attack_magnification));
        TurnEndFlag.EndTurn.Invoke();
    }
}