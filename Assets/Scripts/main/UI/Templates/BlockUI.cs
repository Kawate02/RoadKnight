using System.Threading.Tasks;

public class UI07 : Popup
{
    public UI Init(int sort, Unit unit, float x = 0, float y = 0, UI parent = null)
    {
        float width = 250, height = 700;
        base.Init(false, sort, x, y, width, height, parent);
        images.Add(new Image().Init(Path.UI_Background, sort, x, y, width, height));
        buttons.Add(new Button().Init(sort + 1, x + 15, y + 470, 220, 220, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x + 15, y + 240, 220, 220, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x + 15, y + 10, 220, 220, Path.UI_Button, null, Path.UI_ButtonOver));
        buttons.Add(new Button().Init(sort + 1, x + 50, y + 700, 200, 80, Path.UI_Button, null, Path.UI_ButtonOver));

        buttons[0].ClickEvent += async () => {
            await Task.Delay(1);
            Stage.piece = new Piece().Init(unit.pieces[0], 0, 0, 0);
            Stage.piece.CancelEvent += () => { Enable(); };
            Stage.piece.Holding();
            Disable();
            };

        buttons[1].ClickEvent += async () => {
            await Task.Delay(1);
            Stage.piece = new Piece().Init(unit.pieces[1], 0, 0, 0);
            Stage.piece.CancelEvent += () => { Enable(); };
            Stage.piece.Holding();
            Disable();
            };

        buttons[2].ClickEvent += async () => {
            await Task.Delay(1);
            Stage.piece = new Piece().Init(unit.pieces[2], 0, 0, 0);
            Stage.piece.CancelEvent += () => { Enable(); };
            Stage.piece.Holding();
            Disable();
            };

        buttons[3].ClickEvent += () => {Destroy();};
        return this;
    }
}