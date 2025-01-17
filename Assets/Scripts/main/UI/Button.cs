using System.Net.Http.Headers;

public class Button : UI
{
    protected string buttonText;
    protected string buttonImage;
    protected string cursorOverImage = Path.Unit01;
    new Text text;
    new Image image;
    Image cursorOver;
    public virtual Button Init(int sort, float x = 0, float y = 0, float width = 0, float height = 0)
    {    
        type = UIType.Button;
        base.Init(type, x, y, width, height);
        if (buttonText != null) text = new Text().Init(buttonText, sort + 1, x, y, width, height);
        if (buttonImage != null) image = new Image().Init(buttonImage, sort, x, y, width, height);
        if (cursorOverImage != null) cursorOver = new Image().Init(cursorOverImage, sort + 2, x, y, width, height);
        cursorOver.Disable();
        return this;
    }
    public override void Destroy()
    {
        if (text != null) text.Destroy();
        if (image != null) image.Destroy();
        if (cursorOver != null) cursorOver.Destroy();
        base.Destroy();
    }
    protected virtual void OnClick()
    { 
        Debug.Log("click");
    }
    public override void OnUpdate()
    {
        if (state == UIState.Inactive) return;
        if (pos.x < Input.MousePosition.x && pos.x + size.x > Input.MousePosition.x && pos.y < Input.MousePosition.y && pos.y + size.y > Input.MousePosition.y)
        {
            cursorOver.Enable();
            if (Input.GetAction(Trigger.Mouse_Left).down)
            {
                OnClick();
            }
        }
        else
        {
            cursorOver.Disable();
        }
    }
}