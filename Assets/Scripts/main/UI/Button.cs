using System.Net.Http.Headers;
using System.Threading.Tasks;

public class Button : UIBase
{
    public event System.Action ClickEvent;
    public bool isClick { get; protected set; } = false;
    public bool isOver { get; protected set; } = false;
    protected string _buttonImage;
    protected string _cursorOverImage;
    protected string _clickImage;
    Image buttonImage;
    Image cursorOver;
    Image clickImage;
    public virtual Button Init(int sort, float x = 0, float y = 0, float width = 0, float height = 0, string _buttonImage = null, string _clickImage = null, string _cursorOverImage = null)
    {    
        type = UIType.Button;
        base.Init(type, x, y, width, height);
        if (_buttonImage != null) buttonImage = new Image().Init(_buttonImage, sort, x, y, width, height);
        if (_cursorOverImage != null) 
        {
            cursorOver = new Image().Init(_cursorOverImage, sort + 2, x, y, width, height);
            cursorOver.Disable();
        }
        if (_clickImage != null)
        {
            clickImage = new Image().Init(_clickImage, sort + 3, x, y, width, height);
            clickImage.Disable();
        }
        return this;
    }
    public override void Destroy()
    {
        if (buttonImage != null) buttonImage.Destroy();
        if (cursorOver != null) cursorOver.Destroy();
        if (clickImage != null) clickImage.Destroy();
        base.Destroy();
    }
    protected virtual void OnClick()
    { 
        ClickEvent?.Invoke();
        Debug.Log("OnClick");
    }
    public override void OnUpdate()
    {
        if (state == UIState.Inactive) return;
        if (pos.x < Input.MousePosition.x && pos.x + size.x > Input.MousePosition.x && pos.y < Input.MousePosition.y && pos.y + size.y > Input.MousePosition.y)
        {
            isOver = true;
            if (cursorOver != null) cursorOver.Enable();
            if (Input.GetAction(Trigger.Mouse_Left).down)
            {
                OnClick();
            }
        }
        else
        {
            isOver = false;
            if (cursorOver != null) cursorOver.Disable();
        }
    }
    public override void Move(float x, float y, float offset = 0)
    {
        base.Move(x, y, offset);
        if (buttonImage != null) buttonImage.Move(x, y, offset);
        if (cursorOver != null) cursorOver.Move(x, y, offset);
        if (clickImage != null) clickImage.Move(x, y, offset);
    }
    public override void Enable()
    {
        base.Enable();
        if (buttonImage != null) buttonImage.Enable();
        if (cursorOver != null) cursorOver.Enable();
        if (clickImage != null) clickImage.Enable();
    }
    public override void Disable()
    {
        base.Disable();
        if (buttonImage != null) buttonImage.Disable();
        if (cursorOver != null) cursorOver.Disable();
        if (clickImage != null) clickImage.Disable();
    }
}