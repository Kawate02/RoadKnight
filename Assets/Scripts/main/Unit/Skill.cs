using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class Skill
{
    public SkillBase Init(int id)
    {
        switch (id)
        {
            case 0:
                return new Skill01();
            case 1:
                return new Skill02();
            case 2:
                return new Skill03();
            case 3:
                return new Skill04();
            case 4:
                return new Skill05();
            case 5:
                return new Skill06();
            case 6:
                return new Skill07();
            case 7:
                return new Skill08();
            case 8:
                return new Skill09();
            default:
                return null;
        }
    }
}
public class SkillBase
{
    protected List<Vector3> _range;
    public List<Vector3> range { get; protected set; }
    public List<Vector3> activeRange { get; protected set; } = new List<Vector3>();
    protected Block targetBlock;
    public event System.Action CancelEvent;
    bool cancel;
    protected Unit owner;
    public virtual SkillBase Init() => this;
    public virtual async void Wait(Unit owner)
    {
        this.owner = owner;
        targetBlock = null;
        Init();
        cancel = false;
        Block block;
        Vector3 oldPos = new Vector3(owner.pos);
        SetSkillDirection(owner);
        await AreaCal();
        while (targetBlock == null)
        {
            if (cancel) break;
            if (oldPos != owner.pos) 
            {
                SetSkillDirection(owner);
                await AreaCal();
            }
            oldPos = new Vector3(owner.pos);
            if (Input.GetAction(Trigger.Mouse_Right).down || Input.GetAction(Trigger.Escape).down)
            {
                await Cancel();
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
                        var bpos = new Vector3(block.pos);
                        bpos /= Constant.BlockSize;
                        bpos.y += 1;
                        if (dir == owner.direction)
                        {
                            foreach (var item in activeRange)
                            {
                                if (bpos == item)
                                {
                                    targetBlock = block;
                                    Exe(bpos);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            owner.SetDirection(dir);
                            SetSkillDirection(owner);
                            await AreaCal();
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
    protected void AddPos(Vector3 v)
    {
        if (Stage.field.CanPlace(v) && Stage.field.CanGround(v))
            {
                activeRange.Add(v);
                Stage.skillArea.AddPos(new Vector3(v));
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
    }
    protected virtual async Task AreaCal(Vector3 pos = null)
    {
        await Stage.skillArea.Destroy();
    }
    public async Task Cancel()
    {
        await Stage.skillArea.Destroy();
        CancelEvent?.Invoke();
        cancel = true;
    }
    public virtual void Exe(Vector3 pos)
    {

    }
    protected List<Unit> GetUnits(List<Vector3> pos)
    {
        List<Unit> units = new List<Unit>();
        foreach (var item in pos)
        {
            Unit u = Stage.field.field[(int)item.x, (int)item.y, (int)item.z].unit;
            if (u != null) units.Add(u);
        }
        return units;
    }
    protected Unit GetUnits(Vector3 pos)
    {
        Unit u = Stage.field.field[(int)pos.x, (int)pos.y, (int)pos.z].unit;
        if (u != null) return u;
        return u;
    }
}