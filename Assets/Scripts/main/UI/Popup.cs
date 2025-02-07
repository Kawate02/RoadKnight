public class Popup : UI
{
    protected UI parent;
    bool isTemp = false;
    public virtual UI Init(bool isTemp, int sort, float x = 0, float y = 0, float width = 0, float height = 0, UI parent = null)
    {
        this.isTemp = isTemp;
        if (parent != null)
        {
            this.parent = parent;
            parent.Disable();
            this.sort = parent.sort + 1;
        }
        base.Init(sort, x, y, width, height);
        return this;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (pos.x > Input.MousePosition.x || pos.x + size.x < Input.MousePosition.x || pos.y > Input.MousePosition.y || pos.y + size.y < Input.MousePosition.y)
        {
            if (Input.GetAction(Trigger.Mouse_Left).down && isTemp)
            {
                Destroy();
            }
        }
    }

    public override void Destroy()
    {
        if (parent != null) parent.Enable();
        base.Destroy();
    }
}