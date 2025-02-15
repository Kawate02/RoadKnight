using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill04 : SkillBase
{
    public override SkillBase Init()
    {
        _range = SkillDataBase.Skill04.Range;
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
        owner.AddEffect(new DefenceBuff(4));
        TurnEndFlag.EndTurn.Invoke();
    }
}