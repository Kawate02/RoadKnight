using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill07 : SkillBase
{
    public override SkillBase Init()
    {
        _range = SkillDataBase.Skill07.Range;;
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
        for (int i = 0; i < SkillDataBase.Skill07.attack_buff_stage; i++)
        {
            owner.AddEffect(new AttackBuff(4));
        }
        for (int i = 0; i < SkillDataBase.Skill07.defence_debuff_stage; i++)
        {
            owner.AddEffect(new DefenceDebuff(4));
        }
        TurnEndFlag.EndTurn.Invoke();
    }
}