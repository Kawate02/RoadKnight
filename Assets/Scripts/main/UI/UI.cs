using System.Collections.Generic;

public class UI : UIBase
{
    protected List<Text> texts = new List<Text>();
    protected List<Image> images = new List<Image>();
    protected List<Button> buttons = new List<Button>();
    protected UI children = null;
    public virtual UI Init(int sort, float x = 0, float y = 0, float width = 0, float height = 0)
    {
        this.sort = sort*32;
        type = UIType.UI;
        base.Init(type, x, y, width, height);
        return this;
    }

    public override void Move(float x, float y, float offset = 0)
    {
        for (int i = 0; i < texts.Count; i++) texts[i].Move(x, y, offset);
        for (int i = 0; i < images.Count; i++) images[i].Move(x, y, offset);
        for (int i = 0; i < buttons.Count; i++) buttons[i].Move(x, y, offset);
        base.Move(x, y, offset);
    }
    public override void Destroy()
    {
        for (int i = 0; i < texts.Count; i++) texts[i].Destroy();
        for (int i = 0; i < images.Count; i++) images[i].Destroy();
        for (int i = 0; i < buttons.Count; i++) buttons[i].Destroy();
        base.Destroy();
    }
    public override void Enable()
    {
        for (int i = 0; i < texts.Count; i++) texts[i].Enable();
        for (int i = 0; i < images.Count; i++) images[i].Enable();
        for (int i = 0; i < buttons.Count; i++) buttons[i].Enable();
        base.Enable();
    }
    public override void Disable()
    {
        for (int i = 0; i < texts.Count; i++) texts[i].Disable();
        for (int i = 0; i < images.Count; i++) images[i].Disable();
        for (int i = 0; i < buttons.Count; i++) buttons[i].Disable();
        base.Disable();
    }
}