using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill09 : SkillBase
{
    public override SkillBase Init()
    {
        _range = SkillDataBase.Skill09.Range;
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
        var unit = GetUnits(activeRange);
        
        for (int i = 0; i < unit.Count; i++)
        {
            if (unit[i].IsEnemy(owner)) unit[i].Damage(Formula.Damage(owner.atk, unit[i].def, SkillDataBase.Skill09.attack_magnification));
        }
        for (int i = activeRange.Count - 1; i >= 0; i--)
        {
            if (!Stage.field.ThereIsUnit(activeRange[i]))
            {
                owner.SetPos(activeRange[i].x * Constant.BlockSize, activeRange[i].y * Constant.BlockSize, activeRange[i].z * Constant.BlockSize);
                break;
            }
        }
        TurnEndFlag.EndTurn.Invoke();
    }
}