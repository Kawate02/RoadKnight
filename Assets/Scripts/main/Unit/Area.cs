using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class AreaBase
{
    public List<Vector3> list { get; private set; } = new List<Vector3>();
    List<Area> spriteList = new List<Area>();
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
            spriteList.Add(new Area().Init(path, list[i].x * Constant.BlockSize, (list[i].y - 0.45f) * Constant.BlockSize, list[i].z * Constant.BlockSize));
        }
    }
    public async virtual Task AreaCal(int radius)
    {
        await Destroy();
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
    public async Task Destroy()
    {
        for (int i = 0; i < spriteList.Count; i++)
        {
            spriteList[i].Scale(-1, -1, -1, 10);
        }
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1);
        }
        for (int i = 0; i < spriteList.Count; i++)
        {
            spriteList[i].Destroy();
        }
        list.Clear();
        spriteList.Clear();
        return;
    }
}
public class MoveArea : AreaBase
{
    public async Task AreaCal(Vector3 pos, int radius)
    {
        pos /= Constant.BlockSize;
        await base.AreaCal(radius);
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
    new public void AddPos(Vector3 v)
    {
        if (!HasPos(v))
        {
            v.y += 0.05f;
            list.Add(v);
        }
    }
}

public class Area : Sprite
{
    new public Area Init(string path, float x, float y, float z)
    {
        base.Init(path, x, y, z);
        Rotate(90, 0, 0);
        return this;
    }
    public async void Scale(float x, float y, float z, float offset = 0)
    {
        if (offset == 0)
        {
            scale.x += x;
            scale.y += y;
            scale.z += z;
        }
        else
        {
            float timer = offset;
            while (timer > 0)
            {
                scale.x += x / offset;
                scale.y += y / offset;
                scale.z += z / offset;
                timer -= 1;
                await Task.Delay(1);
            }
        }
        return;
    }
}