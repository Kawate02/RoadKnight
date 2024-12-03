using System;
using System.Collections.Generic;
using System.Diagnostics;

public interface IBeClickable
{
    int OnClick();
}


public class Position 
{
    public Position() 
    {
        x = 0;
        y = 0;
        z = 0;
    }
    public Position(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public float x;
    public float y;
    public float z;
}
public class Object
{
    public Object Init(bool isSprite, int x = 0, int y = 0, int z = 0)
    {
        this.isSprite = isSprite;
        pos = new Position(x, y, z);
        rot = new Position(0, 0, 0);
        scale = new Position(1, 1, 1);
        if (isSprite)
        {
            id = SpriteList.Add(this);
        }
        else
        {
            id = ModelList.Add(this);
        }
        return this;
    }
    ~Object() 
    { 
        Destroy();
    }
    public void Destroy()
    {
        if (isSprite)
        {
            SpriteList.Set(id, null);
        }
        else
        {
            ModelList.Set(id, null);
        }
    }
    public string name { get;protected set; }
    public int id { get;protected set; }
    public bool isSprite { get;protected set; } //Sprite or Model
    public Position pos { get;protected set; }
    public Position rot { get;protected set; }
    public Position scale { get;protected set; }
    public string image { get;protected set; }
    public virtual void OnUpdate() {}
    public virtual void OnClick() {}
    public void Move(float x, float y, float z = 0)
    {
        pos.x += x;
        pos.y += y;
        pos.z += z;
    }
}

public static class SpriteList
{
    private static List<Object> list = new List<Object>();

    public static int Add(Object obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(Object obj)
    {
        list.Remove(obj);
    }
    public static void Set(int id, Object obj)
    {
        list[id] = obj;
    }

    public static List<Object> GetList()
    {
        return list;
    }
    public static void OnUpdate()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].OnUpdate();
        }
    }
}

public static class ModelList
{
    private static List<Object> list = new List<Object>();

    public static int Add(Object obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(Object obj)
    {
        list.Remove(obj);
    }
    public static void Set(int id, Object obj)
    {
        list[id] = obj;
    }

    public static List<Object> GetList()
    {
        return list;
    }
}