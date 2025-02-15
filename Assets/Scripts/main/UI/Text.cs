public class Text : UIBase
{
    public float fontSize = 20;
    public virtual Text Init(string text, Color color, float fontSize, int sort, float x = 0, float y = 0, float width = 0, float height = 0)
    {    
        this.text = text;
        this.sort = sort;
        this.color = color;
        this.fontSize = fontSize;
        type = UIType.Text;
        base.Init(type, x, y, width, height);
        return this;
    }
    public void ChangeText(string text) { this.text = text; }
}