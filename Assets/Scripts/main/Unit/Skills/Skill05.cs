using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill05 : SkillBase
{
    public override SkillBase Init()
    {
        _range = SkillDataBase.Skill05.Range;
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
        if (Stage.field.ThereIsUnit(pos))
        {
            Wait(owner);
            return;
        }
        Jump(pos);
        TurnEndFlag.EndTurn.Invoke();
    }
    void Jump(Vector3 pos)
    {
        owner.SetPos(pos.x * Constant.BlockSize, pos.y * Constant.BlockSize, pos.z * Constant.BlockSize);

        for (int i = 0; i < SkillDataBase.Skill05.Impact.Count; i++)
        {
            var unit = GetUnits(pos + SkillDataBase.Skill05.Impact[i]);
            if (unit != null && unit.IsEnemy(owner)) unit.Damage(Formula.Damage(owner.atk, unit.def, SkillDataBase.Skill05.attack_magnification));
        }
    }
}