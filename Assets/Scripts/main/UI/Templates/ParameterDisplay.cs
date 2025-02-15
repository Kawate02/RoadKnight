public class UI06 : Popup
{
    public UI Init(Unit unit, int sort, float x = 0, float y = 0, UI parent = null)
    {
        float width = 400, height = 500;
        base.Init(true, sort, x, y, width, height, parent);
        images.Add(new Image().Init(Path.UI_Background, sort, x, y, width, height));
        texts.Add(new Text().Init("HP  : " +unit.hp + " / " + unit.max_hp, Color.white, 30, sort + 1, x + 50, y + 450, width));
        texts.Add(new Text().Init("ATK : " +unit.atk, Color.white, 30, sort + 1, x + 50, y + 410, width));
        texts.Add(new Text().Init("DEF : " +unit.def, Color.white, 30, sort + 1, x + 50, y + 370, width));
        texts.Add(new Text().Init("SPD : " +unit.spd, Color.white, 30, sort + 1, x + 50, y + 330, width));
        texts.Add(new Text().Init("MOR : " +unit.move_range, Color.white, 30, sort + 1, x + 50, y + 290, width));

        return this;
    }
}