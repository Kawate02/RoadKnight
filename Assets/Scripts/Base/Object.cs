using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

public enum ObjectType 
{ 
    Sprite, 
    Model,
    Empty
};

public class Vector3 
{
    public Vector3(float x = 0, float y = 0, float z = 0)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }

    //構造体的役割なのでpublic
    public float x;
    public float y;
    public float z;

    //四則演算が出来るようにオーバーロード
    public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.x * b, a.y * b, a.z * b);
    public static Vector3 operator /(Vector3 a, float b) => new Vector3(a.x / b, a.y / b, a.z / b);

    //参照型同士で比較可能にする
    public static bool operator ==(Vector3 a, Vector3 b)
    {
        if (a.x == b.x && a.y == b.y && a.z == b.z) return true;
        else return false;
    }
    public static bool operator !=(Vector3 a, Vector3 b)
    {
        if (a.x == b.x && a.y == b.y && a.z == b.z) return false;
        else return true;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        Vector3 v = (Vector3)obj;
        if (x == v.x && y == v.y && z == v.z) return true;
        else return false;
    }
    public override int GetHashCode()
    {
        return this.x.GetHashCode() ^ this.y.GetHashCode() ^ this.z.GetHashCode();
    }

    new public string ToString() => "(" + x + ", " + y + ", " + z + ")";
}
public class Object
{
    public virtual Object Init(ObjectType type, float x = 0, float y = 0, float z = 0)
    {
        this.drawType = type;

        pos = new Vector3(x, y, z);
        rot = new Vector3(0, 0, 0);
        scale = new Vector3(1, 1, 1);
        
        if (type == ObjectType.Sprite)
        {
            id = SpriteList.Add(this);
        }
        else if(type == ObjectType.Model)
        {
            id = ModelList.Add(this);
        }
        else if(type == ObjectType.Empty)
        {
            id = EmptyList.Add(this);
        }
        return this;
    }
    public virtual void Destroy()
    {
        if (drawType == ObjectType.Sprite)
        {
            SpriteList.Set(id, null);
        }
        else if (drawType == ObjectType.Model)
        {
            ModelList.Set(id, null);
        }
        else if (drawType == ObjectType.Empty)
        {
            EmptyList.Set(id, null);
        }
    }
    public string name { get;protected set; }
    public int id { get;protected set; }
    public ObjectType drawType { get;protected set; }
    public Vector3 pos { get;protected set; }
    public Vector3 rot { get;protected set; }
    public Vector3 scale { get;protected set; }
    public string image { get;protected set; } = "";
    public string material { get;protected set; } = "";
    public Vector3 collisonSize { get; protected set; } = new Vector3(0, 0, 0);
    public virtual void OnUpdate() {}
    public async virtual void Move(float x, float y, float z, float offset = 0)
    {
        if (offset == 0)
        {
            pos.x += x;
            pos.y += y;
            pos.z += z;
        }
        else
        {
            float timer = offset;
            while (timer > 0)
            {
                pos.x += x / offset;
                pos.y += y / offset;
                pos.z += z / offset;
                timer -= 1;
                await Task.Delay(1);
            }
        }
    }
    public async virtual void Move(Vector3 v, float offset = 0)
    {
        if (offset == 0)
        {
            pos.x += v.x;
            pos.y += v.y;
            pos.z += v.z;
        }
        else
        {
            float timer = offset;
            while (timer > 0)
            {
                pos.x += v.x / offset;
                pos.y += v.y / offset;
                pos.z += v.z / offset;
                timer -= 1;
                await Task.Delay(1);
            }
        }
    }
    public virtual void SetPos(float x, float y, float z)
    {
        pos = new Vector3(x, y, z);
    }

    public async virtual void Rotate(float x, float y, float z, float offset = 0)
    {
        if (offset == 0)
        {
            rot.x += x;
            rot.y += y;
            rot.z += z;
        }
        else
        {
            float timer = offset;
            while (timer > 0)
            {
                rot.x += x / offset;
                rot.y += y / offset;
                rot.z += z / offset;
                timer -= 1;
                await Task.Delay(1);
            }
        }
    }

    public virtual void SetScale(float x, float y, float z)
    {
        scale.x = x;
        scale.y = y;
        scale.z = z;
    }

    public void IdAdjust(int id)
    {
        this.id = id;
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
        list.RemoveAt(obj.id);
    }
    public static void Set(int id, Object obj)
    {
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
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
    private static void ListClose(int index)
    {
        for (int i = index; i < list.Count - 1; i++)
        {
            list[i] = list[i + 1];
            list[i].IdAdjust(i);
        }
        list.RemoveAt(list.Count - 1);
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
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
    }

    public static List<Object> GetList()
    {
        return list;
    }
    public static void OnUpdate()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null) list[i].OnUpdate();
        }
    }
    private static void ListClose(int index)
    {
        for (int i = index; i < list.Count - 1; i++)
        {
            list[i] = list[i + 1];
            list[i].IdAdjust(i);
        }
        list.RemoveAt(list.Count - 1);
    }
}

public static class EmptyList
{
    private static List<Object> list = new List<Object>();

    public static int Add(Object obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(Object obj)
    {
        list.RemoveAt(obj.id);
    }
    public static void Set(int id, Object obj)
    {
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
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
    private static void ListClose(int index)
    {
        for (int i = index; i < list.Count - 1; i++)
        {
            list[i] = list[i + 1];
            list[i].IdAdjust(i);
        }
        list.RemoveAt(list.Count - 1);
    }
}