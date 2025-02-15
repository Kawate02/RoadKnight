public class UI05 : UI
{
    public UI04 hp { get; private set; }
    public UI08 effects { get; private set; }
    public UI05 Init(int sort, Unit unit, float x = 0, float y = 0)
    {
        float width = 400, height = 100;
        base.Init(sort, x, y, width, height);
        buttons.Add(new Button().Init(sort, x, y, width, height, Path.UI_Background));
        buttons[0].ClickEvent += () => {new UI06().Init(unit, sort + 1, 1100, 30);};
        texts.Add(new Text().Init(unit.name, Color.white, 30, sort + 1, x + 10, y + 100, width));
        hp = new UI04().Init(sort + 1, unit, x, y);
        effects = new UI08().Init(sort + 2, unit, x, y - 25);
        return this;
    }
}