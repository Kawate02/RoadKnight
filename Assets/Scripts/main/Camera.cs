public static class Cam
{
    public static Vector3 pos { get; private set; }
    public static Vector3 rot { get; private set; }

    public static void Init(float x, float y, float z, float rx, float ry, float rz)
    {
        pos = new Vector3(x, y, z);
        rot = new Vector3(rx, ry, rz);
    }

    public static async void Move(float x, float y, float z, float offset = 0)
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
                await System.Threading.Tasks.Task.Delay(1);
            }
        }
    }

    public static async void Rotate(float x, float y, float z, float offset = 0)
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
                await System.Threading.Tasks.Task.Delay(1);
            }
        }
    }
}