using System.Threading.Tasks;
using UnityEngine;

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
            Debug.Log(dir.x);
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
        float x = Mathf.Sin(rot) * Constant.FieldWidth * Constant.BlockSize / 1.2f;
        float z = Mathf.Cos(rot) * Constant.FieldDepth * Constant.BlockSize / 1.2f;
        float y = Mathf.Atan(Mathf.Sin(rot) / Mathf.Cos(rot)) * 180f / Mathf.PI;
        if (Mathf.Cos(rot) > 0) y += 180;
        float c = Mathf.Sqrt(x * x + z * z);
        x += Constant.FieldWidth * Constant.BlockSize / 2;
        z += Constant.FieldDepth * Constant.BlockSize / 2;
        Cam.SetPos(x, Cam.pos.y, z);
        Cam.SetRotate(50 - c, y, Cam.rot.z);
    }

    public void EndView()
    {
        end = true;
    }
}