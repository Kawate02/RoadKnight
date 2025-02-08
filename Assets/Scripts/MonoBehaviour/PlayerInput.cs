using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UInput = UnityEngine.Input;

public class PlayerInput : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    Ray ray;
    public void Init()
    {
        Input.Init();
    }
    public void OnUpdate()
    {
        ray = Camera.main.ScreenPointToRay(UInput.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Input.SetChoiceBlock(hit.transform.gameObject.GetComponent<Obj>().GetId());
        }
        else
        {
            Input.SetChoiceBlock(-1);
        }

        var mousePos = UInput.mousePosition;
        Vector3 vec = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        Input.SetMousePosition(vec);
        var worldMousePos = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector3(mousePos.x, mousePos.y, 10));
        vec = new Vector3(worldMousePos.x, worldMousePos.y, worldMousePos.z);
        Input.SetWorldMousePosition(vec);
        
        if  (UInput.mouseScrollDelta.y > 0)
        {
            Input.SetScroll(1);
        }
        else if (UInput.mouseScrollDelta.y < 0)
        {
            Input.SetScroll(-1);
        }
        else
        {
            Input.SetScroll(0);
        }

        if (UInput.GetKeyDown(KeyCode.RightArrow))
        {
            Input.Set(Trigger.Move_Right, true);
        }
        if (UInput.GetKeyDown(KeyCode.LeftArrow))
        {
            Input.Set(Trigger.Move_Left, true);
        }
        if (UInput.GetKeyDown(KeyCode.UpArrow))
        {
            Input.Set(Trigger.Move_Up, true);
        }
        if (UInput.GetKeyDown(KeyCode.DownArrow))
        {
            Input.Set(Trigger.Move_Down, true);
        }
        if (UInput.GetMouseButtonDown(0))
        {
            Input.Set(Trigger.Mouse_Left, true);
        }
        if (UInput.GetMouseButtonDown(1))
        {
            Input.Set(Trigger.Mouse_Right, true);
        }
        if (UInput.GetKeyDown(KeyCode.A))
        {
            Input.Set(Trigger.Camera_Move_Left, true);
            Input.Set(Trigger.Rotate_X, true);
        }
        if (UInput.GetKeyDown(KeyCode.S))
        {
            Input.Set(Trigger.Rotate_Y, true);
        }
        if (UInput.GetKeyDown(KeyCode.D))
        {
            Input.Set(Trigger.Camera_Move_Right, true);
            Input.Set(Trigger.Rotate_Z, true);
        }
        if (UInput.GetKeyDown(KeyCode.Escape))
        {
            Input.Set(Trigger.Escape, true);
        }
        if (UInput.GetKeyDown(KeyCode.Alpha1))
        {
            Input.Set(Trigger.ViewMode, true);
        }

        if (UInput.GetKeyUp(KeyCode.RightArrow))
        {
            Input.Set(Trigger.Move_Right, false);
        }
        if (UInput.GetKeyUp(KeyCode.LeftArrow))
        {
            Input.Set(Trigger.Move_Left, false);
        }
        if (UInput.GetKeyUp(KeyCode.UpArrow))
        {
            Input.Set(Trigger.Move_Up, false);
        }
        if (UInput.GetKeyUp(KeyCode.DownArrow))
        {
            Input.Set(Trigger.Move_Down, false);
        }
        if (UInput.GetMouseButtonUp(0))
        {
            Input.Set(Trigger.Mouse_Left, false);
        }
        if (UInput.GetMouseButtonUp(1))
        {
            Input.Set(Trigger.Mouse_Right, false);
        }
        if (UInput.GetKeyUp(KeyCode.A))
        {
            Input.Set(Trigger.Camera_Move_Left, false);
            Input.Set(Trigger.Rotate_X, false);
        }
        if (UInput.GetKeyUp(KeyCode.S))
        {
            Input.Set(Trigger.Rotate_Y, false);
        }
        if (UInput.GetKeyUp(KeyCode.D))
        {
            Input.Set(Trigger.Camera_Move_Right, false);
            Input.Set(Trigger.Rotate_Z, false);
        }
        if (UInput.GetKeyUp(KeyCode.Escape))
        {
            Input.Set(Trigger.Escape, false);
        }
        if (UInput.GetKeyUp(KeyCode.Alpha1))
        {
            Input.Set(Trigger.ViewMode, false);
        }

        Input.OnUpdate();
    }
}
