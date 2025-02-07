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
                return new Skill01().Init();
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
    public virtual async void Wait(Unit owner)
    {
        cancel = false;
        Block block;
        Vector3 oldPos = new Vector3(owner.pos);
        SetSkillDirection(owner);
        while (targetBlock == null)
        {
            if (cancel) break;
            if (oldPos != owner.pos) SetSkillDirection(owner);
            oldPos = new Vector3(owner.pos);
            if (Input.GetAction(Trigger.Mouse_Right).down)
            {
                Cancel();
                break;
            }
            if (Input.GetAction(Trigger.Mouse_Left).down)
            {
                block = (Block)ModelList.GetList()[Input.ChoiceBlock];
                if (block != null)
                {
                    var dir = SetDirection(owner, block.pos);
                    if (dir == owner.direction)
                    {
                        Exe(block);
                        break;
                    }
                    else
                    {
                        owner.SetDirection(SetDirection(owner, block.pos));
                        SetSkillDirection(owner);
                    }
                }
            }
            await Task.Delay(1);
        }
        Debug.Log("Wait End");
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
        for (int i = 0; i < _range.Count; i++) Debug.Log(range[i].ToString());
        Stage.skillArea.AreaCal(range);
    }
    public void Cancel()
    {
        Stage.skillArea.Destroy();
        CancelEvent?.Invoke();
        cancel = true;
    }
    public virtual void Exe(Block block)
    {
        Stage.skillArea.Destroy();
        ExeEvent?.Invoke();
    }
}