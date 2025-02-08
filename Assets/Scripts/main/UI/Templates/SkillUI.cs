using System.Threading.Tasks;

public class UI02 : Popup
{
    Unit unit;
    UI display;
    public UI Init(int _sort, Unit unit, float x = 0, float y = 0, UI parent = null)
    {
        this.unit = unit;
        float width = 500, height = 300;
        base.Init(false, _sort, x, y, width, height, parent);
        images.Add(new Image().Init(Path.UI_Background, sort, x, y, width, height));
        buttons.Add(new Button().Init(sort + 1, x + 10, y + 20, 480, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x + 10, y + 110, 480, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x + 10, y + 200, 480, 80, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x + 300, y + 300, 200, 80, Path.UI_Button, null, Path.UI_ButtonOver));

        unit.skills[2].CancelEvent += () => {Enable();display.Move(300, 20);};
        unit.skills[1].CancelEvent += () => {Enable();display.Move(300, 20);};
        unit.skills[0].CancelEvent += () => {Enable();display.Move(300, 20);};
        display = new UI03().Init(_sort, 330, 30, parent);

        buttons[0].ClickEvent += async () => {
            await Task.Delay(1);
            display.Move(-300, -20);
            unit.skills[2].Wait(unit);
            Disable();
        };
        buttons[1].ClickEvent += async () => {
            unit.skills[1].CancelEvent += () => {Enable();};
            await Task.Delay(1);
            display.Move(-300, -20);
            unit.skills[1].Wait(unit);
            Disable();
        };
        buttons[2].ClickEvent += async () => {
            unit.skills[0].CancelEvent += () => {Enable();};
            await Task.Delay(1);
            display.Move(-300, -20);
            unit.skills[0].Wait(unit);
            Disable();
        };
        buttons[3].ClickEvent += () => {Destroy();};
        return this;
    }

    public override void Destroy()
    {
        display.Destroy();
        base.Destroy();
    }
}