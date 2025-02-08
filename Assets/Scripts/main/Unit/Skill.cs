using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Skill
{
    public SkillBase Init(int id)
    {
        switch (id)
        {
            case 1:
                return new Skill01();
            default:
                return null;
        }
    }
}
public class SkillBase
{
    protected List<Vector3> _range;
    public List<Vector3> range { get; protected set; }
    Block targetBlock;
    public event System.Action CancelEvent;
    public event System.Action ExeEvent;
    bool cancel;
    protected Unit owner;
    public virtual SkillBase Init() => this;
    public virtual async void Wait(Unit owner)
    {
        this.owner = owner;
        Init();
        cancel = false;
        Block block;
        Vector3 oldPos = new Vector3(owner.pos);
        SetSkillDirection(owner);
        while (targetBlock == null)
        {
            if (cancel) break;
            if (oldPos != owner.pos) SetSkillDirection(owner);
            oldPos = new Vector3(owner.pos);
            if (Input.GetAction(Trigger.Mouse_Right).down || Input.GetAction(Trigger.Escape).down)
            {
                Cancel();
                break;
            }
            if (Input.GetAction(Trigger.Mouse_Left).down)
            {
                if (Input.ChoiceBlock != -1) 
                {
                    block = (Block)ModelList.GetList()[Input.ChoiceBlock];
                    if (block != null)
                    {
                        var dir = SetDirection(owner, block.pos);
                        if (dir == owner.direction)
                        {
                            Exe();
                            break;
                        }
                        else
                        {
                            owner.SetDirection(SetDirection(owner, block.pos));
                            SetSkillDirection(owner);
                        }
                    }
                }
            }
            await Task.Delay(1);
        }
    }
    private Direction SetDirection(Unit owner, Vector3 v)
    {
        v = (v -owner.pos)/Constant.BlockSize;
        if (Math.Abs(v.x) > Math.Abs(v.z))
        {
            if (v.x > 0) return Direction.Right;
            else return Direction.Left;
        }
        else
        {
            if (v.z > 0) return Direction.Up;
            else return Direction.Down;
        }
    }
    private void SetSkillDirection(Unit owner)
    {
        range = new List<Vector3>(_range);
        for (int i = 0; i < _range.Count; i++)
        {
            switch (owner.direction)
            {
                case Direction.Up:
                    range[i] = new Vector3(-_range[i].z, _range[i].y, _range[i].x);
                    range[i] += owner.pos/Constant.BlockSize;
                    break;
                case Direction.Down:
                    range[i] = new Vector3(_range[i].z, _range[i].y, -_range[i].x);
                    range[i] += owner.pos/Constant.BlockSize;
                    break;
                case Direction.Right:
                    range[i] += owner.pos/Constant.BlockSize;
                    break;
                case Direction.Left:
                    range[i] = new Vector3(-_range[i].x, _range[i].y, -_range[i].z);
                    range[i] += owner.pos/Constant.BlockSize;
                    break;
            }
        }
        AreaCal();
    }
    protected virtual void AreaCal()
    {
        Stage.skillArea.Destroy();
    }
    public void Cancel()
    {
        Stage.skillArea.Destroy();
        CancelEvent?.Invoke();
        cancel = true;
    }
    public virtual void Exe()
    {
        ExeEvent?.Invoke();
    }
    public List<Unit> GetUnits(List<Vector3> pos)
    {
        List<Unit> units = new List<Unit>();
        foreach (var item in pos)
        {
            Unit u = Stage.field.field[(int)item.x, (int)item.y, (int)item.z].unit;
            if (u != null) units.Add(u);
        }
        return units;
    }
}