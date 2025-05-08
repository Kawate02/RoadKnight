using System.Threading.Tasks;

public class UI01 : UI
{
    Unit unit;
    public UI Init(int _sort,Unit unit, float x = 0, float y = 0)
    {
        Debug.Log("TurnUI");
        this.unit = unit;
        float width = 400, height = 280;
        base.Init(_sort, x, y, width, height);
        buttons.Add(new Button().Init(sort + 1, x, y, width, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x, y + 100, width, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x, y + 200, width, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons[2].ClickEvent += async () => {
            await Task.Delay(1);
            children = new UI02().Init(sort + 3, unit, 350, 450, this);
            };
        buttons[1].ClickEvent += async () => { 
            await Task.Delay(1);
            children = new UI07().Init(sort + 3, unit, 350, 150, this); 
            };
        buttons[0].ClickEvent += () => { TurnEndFlag.EndTurn.Invoke(); };
        // texts.Add(new Text().Init("SKILL", Color.black, 60, sort + 2, x + 10, y + 270, width));
        // texts.Add(new Text().Init("BLOCK", Color.black, 60, sort + 2, x + 10, y + 170, width));
        // texts.Add(new Text().Init("SKIP", Color.black, 60, sort + 2, x + 10, y + 70, width));
        return this;
    }

    public override void Destroy()
    {
        children?.Destroy();
        base.Destroy();
    }
}