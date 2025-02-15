using System.Collections.Generic;
using System.Threading.Tasks;

public enum UIType
{
    UI,
    Text,
    Image,
    Button
}
public enum UIState
{ 
    Active,
    Inactive
};

public class Vector2
{
    public Vector2(float x = 0, float y = 0)
    {
        this.x = x;
        this.y = y;
    }
    public float x;
    public float y;
    public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);

    new public string ToString() => "(" + x + ", " + y + ")";
}

public class UIBase
{
    public virtual UIBase Init(UIType type, float x = 0, float y = 0, float width = 0, float height = 0)
    {
        this.type = type;
        state = UIState.Active;
        pos = new Vector2(x, y);
        size = new Vector2(width, height);

        if (type == UIType.UI)
        {
            id = UIList.Add(this);
        }
        else if (type == UIType.Image)
        {
            id = ImageList.Add(this);
        }
        else if (type == UIType.Text)
        {
            id = TextList.Add(this as Text);
        }
        else if (type == UIType.Button)
        {
            id = ButtonList.Add(this);
        }

        return this;
    }
    public virtual void Destroy()
    {
        if (type == UIType.UI)
        {
            UIList.Set(id, null);
        }
        else if (type == UIType.Image)
        {
            ImageList.Set(id, null);
        }
        else if (type == UIType.Text)
        {
            TextList.Set(id, null);
        }
        else if (type == UIType.Button)
        {
            ButtonList.Set(id, null);
        }
    }
    public string name { get;protected set; }
    public string image { get;protected set; }
    public string text { get;protected set; }
    public int id { get;protected set; }
    public int sort { get;protected set; }
    public Color color = new Color(1, 1, 1, 1);
    public UIState state { get;protected set; }
    public UIType type { get;protected set; }
    public Vector2 pos { get;protected set; }
    public Vector2 size { get;protected set; }
    public Vector3 scale { get;protected set; }
    public virtual void OnUpdate() {}
    public async virtual void Move(float x, float y, float offset = 0)
    {
        if (offset == 0)
        {
            pos.x += x;
            pos.y += y;
        }
        else
        {
            float timer = offset;
            while (timer > 0)
            {
                pos.x += x / offset;
                pos.y += y / offset;
                timer -= 1;
                await Task.Delay(1);
            }
        }
    }
    public virtual void SetPos(float x, float y)
    {
        pos = new Vector2(x, y);
    }
    public async virtual void Scale(float x, float y, float z, float offset = 0)
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
    }
    public virtual void Enable()
    {
        state = UIState.Active;
    }
    public virtual void Disable()
    {
        state = UIState.Inactive;
    }

    public void IdAdjust(int id)
    {
        this.id = id;
    }
}

public static class ImageList
{
    private static List<UIBase> list = new List<UIBase>();

    public static int Add(UIBase obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(UIBase obj)
    {
        list.RemoveAt(obj.id);
    }
    public static void Set(int id, UIBase obj)
    {
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
    }

    public static List<UIBase> GetList()
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

public static class TextList
{
    private static List<Text> list = new List<Text>();

    public static int Add(Text obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(Text obj)
    {
        list.RemoveAt(obj.id);
    }
    public static void Set(int id, Text obj)
    {
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
    }

    public static List<Text> GetList()
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

public static class ButtonList
{
    private static List<UIBase> list = new List<UIBase>();

    public static int Add(UIBase obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(UIBase obj)
    {
        list.RemoveAt(obj.id);
    }
    public static void Set(int id, UIBase obj)
    {
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
    }

    public static List<UIBase> GetList()
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

public static class UIList
{
    private static List<UIBase> list = new List<UIBase>();

    public static int Add(UIBase obj)
    {
        list.Add(obj);
        return list.Count - 1;
    }

    public static void Remove(UIBase obj)
    {
        list.RemoveAt(obj.id);
    }
    public static void Set(int id, UIBase obj)
    {
        if (id >= list.Count) return;
        list[id] = obj;
        if (obj == null) ListClose(id);
    }

    public static List<UIBase> GetList()
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