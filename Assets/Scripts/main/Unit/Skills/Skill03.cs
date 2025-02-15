using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill03 : SkillBase
{
    public override SkillBase Init()
    {
        _range = SkillDataBase.Skill03.Range;
        return this;
    }
    protected override async Task AreaCal(Vector3 pos = null) 
    {
        await base.AreaCal();
        for (int i = 0; i < range.Count; i++)
        {
            AddPos(range[i]);
        }
        Stage.skillArea.Enable(Path.UI_Attack_Area);
    }
    public async override void Exe(Vector3 pos)
    {
        await Stage.skillArea.Destroy();
        var _unit = GetUnits(activeRange);
        var unit = new List<Unit>();
        for (int i = 0; i < _unit.Count; i++)
        {
            if (_unit[i] != null && _unit[i].IsEnemy(owner)) unit.Add(_unit[i]);
        }
        for (int i = 0; i < SkillDataBase.Skill03.attack_count; i++)
        {
            Random rnd = new Random();
            int j = rnd.Next(0, unit.Count);
            unit[j].Damage(Formula.Damage(owner.atk, unit[j].def, SkillDataBase.Skill03.attack_magnification));
        }
        TurnEndFlag.EndTurn.Invoke();
    }
}