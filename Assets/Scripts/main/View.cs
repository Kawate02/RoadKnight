using System.Threading.Tasks;
using System;

public class View
{
    Vector3 pos = new Vector3();
    float rot = 3;
    bool end;
    public void Init()
    {
        end = false;
        SetPos();
    }
    public void OnUpdate()
    {
        if (Input.GetAction(Trigger.Mouse_Left).down)
        {
            pos = Input.MousePosition;
        }
        if (Input.GetAction(Trigger.Mouse_Left).value)
        {
            var dir = Input.MousePosition - pos;
            if (dir.x > 0)
            {
                Move(false, 0.11f, false);
                pos = Input.MousePosition;
            }
            else if (dir.x < 0)
            {
                Move(true, 0.11f, false);
                pos = Input.MousePosition;
            }
        }
        if (Input.GetAction(Trigger.Mouse_Left).up)
        {
            var dir = Input.MousePosition - pos;
            if (dir.x > 0)
            {
                Move(false, dir.x/100, false);
                pos = Input.MousePosition;
            }
            else if (dir.x < 0)
            {
                Move(true, -dir.x/100, false);
                pos = Input.MousePosition;
            }
        }
        if (Input.GetAction(Trigger.Camera_Move_Right).value)
        {
            Move(true, 1, true);
        }
        else if (Input.GetAction(Trigger.Camera_Move_Left).value)
        {
            Move(false, 1, true);
        }
    }
    async void Move(bool right, float speed, bool uni = true)
    {
        if (uni)
        {
            if (right)
            {
                rot -= speed / 100;
            }
            else
            {
                rot += speed / 100;
            }
            SetPos();
        }
        else
        {
            while (speed > 0)
            {
                if (end) break;
                if (Input.GetAction(Trigger.Mouse_Left).down) break;
                if (right)
                {
                    rot -= speed / 100;
                }
                else
                {
                    rot += speed / 100;
                }
                SetPos();
                speed -= 1 * speed / 100;
                speed = speed <= 0.1f ? 0 : speed;
                await Task.Delay(1);
            }
        }
        
    }
    void SetPos()
    {
        var x = Math.Sin(rot) * Constant.FieldWidth * Constant.BlockSize / 1.2f;
        var z = Math.Cos(rot) * Constant.FieldDepth * Constant.BlockSize / 1.2f;
        var y = Math.Atan(Math.Sin(rot) / Math.Cos(rot)) * 180f / Math.PI;
        if (Math.Cos(rot) > 0) y += 180;
        var c = Math.Sqrt(x * x + z * z);
        x += Constant.FieldWidth * Constant.BlockSize / 2;
        z += Constant.FieldDepth * Constant.BlockSize / 2;
        Cam.SetPos((float)x, Cam.pos.y, (float)z);
        Cam.SetRotate(50 - (float)c, (float)y, Cam.rot.z);
    }

    public void EndView()
    {
        end = true;
    }
}