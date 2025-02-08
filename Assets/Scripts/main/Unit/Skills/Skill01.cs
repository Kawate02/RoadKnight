using System.Collections.Generic;

public class Skill01 : SkillBase
{
    public override SkillBase Init()
    {
        _range = new List<Vector3>() {new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0)};
        return this;
    }
    protected override void AreaCal() 
    {
        base.AreaCal();
        for (int i = 0; i < base.range.Count; i++)
        {
            if (Stage.field.CanPlace(range[i]) && Stage.field.CanGround(range[i]))
            {
                Stage.skillArea.AddPos(range[i]);
            }
        }
        Stage.skillArea.Enable(Path.UI_Attack_Area);
    }
    public override void Exe()
    {
        Stage.skillArea.Destroy();
        Stage.moveArea.Destroy();
        var units = GetUnits(range);
        for (int i = 0; i < units.Count; i++) if (units[i].IsEnemy(owner)) units[i].Damage(Formula.Damage(owner.atk, units[i].def));
        TurnEndFlag.EndTurn.Invoke();
    }
}