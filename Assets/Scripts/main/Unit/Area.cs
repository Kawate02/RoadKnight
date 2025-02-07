using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AreaBase
{
    public List<Vector3> list { get; private set; } = new List<Vector3>();
    List<Sprite> spriteList = new List<Sprite>();
    public bool HasPos(Vector3 pos)
    {
        foreach (var item in list)
        {
            if (item == pos) return true;
        }
        return false;
    }
    public void Enable(string path) 
    {
        spriteList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            spriteList.Add(new Sprite().Init(path, list[i].x * Constant.BlockSize, (list[i].y-0.45f) * Constant.BlockSize, list[i].z * Constant.BlockSize));
            spriteList[i].Rotate(90, 0, 0);
        }
    }
    public virtual void AreaCal(int radius)
    {
        Destroy();
        list.Clear();
        if (radius < 0) return;
    }
    protected virtual void AddPos(Vector3 v)
    {
        for (int i = (int)v.y+1; i > 0; i--)
        {
            v.y = i;
            if (!HasPos(v) && Stage.field.CanPlace(v) && Stage.field.CanGround(v) && !Stage.field.ThereIsUnit(v))
            {
                list.Add(v);
                break;
            }
        }
    }
    public void Destroy()
    {
        for (int i = 0; i < spriteList.Count; i++)
        {
            spriteList[i].Destroy();
        }
    }
}
public class MoveArea : AreaBase
{
    public void AreaCal(Vector3 pos, int radius)
    {
        pos /= Constant.BlockSize;
        base.AreaCal(radius);
        list.Add(pos);
        for (int i = 0; i < radius; i++)
        {
            int l = list.Count;
            for (int j = 0; j < l; j++)
            {
                AddPos(new Vector3(list[j].x+1, list[j].y, list[j].z));
                AddPos(new Vector3(list[j].x-1, list[j].y, list[j].z));
                AddPos(new Vector3(list[j].x, list[j].y, list[j].z+1));
                AddPos(new Vector3(list[j].x, list[j].y, list[j].z-1));
            }
        }
        Enable(Path.UI_Move_Area);
    }
}
public class SkillArea : AreaBase
{
    public void AreaCal(List<Vector3> pos)
    {
        base.AreaCal(1);
        for (int i = 0; i < pos.Count; i++)
        {
            AddPos(pos[i]);
        }
        Enable(Path.UI_Attack_Area);
    }
    protected override void AddPos(Vector3 v)
    {
        if (!HasPos(v) && Stage.field.CanPlace(v) && Stage.field.CanGround(v))
        {
            v.y += 0.05f;
            list.Add(v);
        }
    }
}