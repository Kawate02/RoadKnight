using System.Collections.Generic;

public class Skill01 : SkillBase
{
    public SkillBase Init()
    {
        _range = new List<Vector3>() {new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0)};
        return this;
    }
    public override void Exe(Block block)
    {
        base.Exe(block);
    }
}