public enum Trigger
{
    Move_Right,
    Move_Left,
    Move_Up,
    Move_Down,
    Camera_Move_Right,
    Camera_Move_Left,
    Mouse_Left,
    Mouse_Right,
    Rotate_X,
    Rotate_Y,
    Rotate_Z,
    ViewMode,
    Escape,
    Space,
    Count
}

public class Action
{
    Trigger trigger;
    public bool value { get; private set; } = false;
    private bool lastValue = false;
    public bool down { get; private set; } = false;
    public bool up { get; private set; } = false;

    public Action(Trigger trigger)
    {
        this.trigger = trigger;
    }

    public void Set(bool value)
    {
        this.value = value;
    }

    public void OnUpdate()
    {
        if (value == lastValue)
        {
            down = false;
            up = false;
        }
        if (value != lastValue)
        {
            if (value)
            {
                down = true;
            }
            else
            {
                up = true;
            }
        }
        lastValue = value;
    }
}

public static class Input
{
    private static Action[] actions = new Action[(int)Trigger.Count];
    public static Vector3 MousePosition { get; private set; }
    public static Vector3 WorldMousePosition { get; private set; }
    public static float Scroll { get; private set; } = 0;
    public static int ChoiceBlock { get; private set; }
    public static void Init()
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i] = new Action((Trigger)i);
        }
    }
    public static void Set(Trigger trigger, bool value)
    {
        actions[(int)trigger].Set(value);
    }
    
    public static void OnUpdate()
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].OnUpdate();
        }
    }
    public static void SetMousePosition(Vector3 position) => MousePosition = position;
    public static void SetWorldMousePosition(Vector3 position) => WorldMousePosition = position;
    public static void SetScroll(float scroll) => Scroll = scroll;
    public static void SetChoiceBlock(int block) => ChoiceBlock = block;
    public static Action GetAction(Trigger trigger) => actions[(int)trigger];
}