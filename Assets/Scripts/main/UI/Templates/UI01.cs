using System.Threading.Tasks;

public class UI01 : UI
{
    Unit unit;
    public UI Init(int _sort,Unit unit, float x = 0, float y = 0)
    {
        this.unit = unit;
        float width = 400, height = 280;
        base.Init(_sort, x, y, width, height);
        buttons.Add(new Button().Init(sort + 1, x, y, width, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x, y + 100, width, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x, y + 200, width, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons[2].ClickEvent += async () => {
            await Task.Delay(1);
            children = new UI02().Init(sort + 2, unit, 350, 450, this);
            };
        return this;
    }

    public override void Destroy()
    {
        children?.Destroy();
        base.Destroy();
    }
}