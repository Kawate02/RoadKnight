public class UI06 : Popup
{
    public UI Init(int sort, float x = 0, float y = 0, UI parent = null)
    {
        float width = 400, height = 500;
        base.Init(true, sort, x, y, width, height, parent);
        images.Add(new Image().Init(Path.UI_Background, sort, x, y, width, height));
        return this;
    }
}