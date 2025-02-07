public class UI03 : Popup
{
    public UI Init(int _sort, float x = 0, float y = 0, UI parent = null)
    {
        float width = 540, height = 400;
        base.Init(false, _sort, x, y, width, height, parent);
        images.Add(new Image().Init(Path.UI_Background, sort, x, y, width, height));
        return this;
    }

    public override void OnUpdate()
    {
        
    }
}