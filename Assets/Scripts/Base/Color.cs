public class Color
{
    private float r;
    public float R
    {
        get => r;
        set
        {
            if (value < 0) r = 0;
            else if (value > 1) r = 1;
            else r = value;
        }
    }
    private float g;
    public float G
    {
        get => g;
        set
        {
            if (value < 0) g = 0;
            else if (value > 1) g = 1;
            else g = value;
        }
    }
    private float b;
    public float B
    {
        get => b;
        set
        {
            if (value < 0) b = 0;
            else if (value > 1) b = 1;
            else b = value;
        }
    }
    private float a;
    public float A
    {
        get => a;
        set
        {
            if (value < 0) a = 0;
            else if (value > 1) a = 1;
            else a = value;
        }
    }
    public Color(float r, float g, float b, float a = 1f)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }
    public static Color white => new Color(1f, 1f, 1f, 1f);
    public static Color black => new Color(0f, 0f, 0f, 1f);
    public static Color red => new Color(1f, 0f, 0f, 1f);
    public static Color green => new Color(0f, 1f, 0f, 1f);
    public static Color blue => new Color(0f, 0f, 1f, 1f);
    public static Color yellow => new Color(1f, 1f, 0f, 1f);
    public static Color magenta => new Color(1f, 0f, 1f, 1f);
    public static Color cyan => new Color(0f, 1f, 1f, 1f);
    public static Color gray => new Color(0.5f, 0.5f, 0.5f, 1f);
    public static Color clear => new Color(0f, 0f, 0f, 0f);
}