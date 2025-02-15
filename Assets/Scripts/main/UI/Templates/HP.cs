using System.Threading.Tasks;
using System;

public class UI04 : UI
{
    Unit unit;
    public UI04 Init(int _sort, Unit unit, float x = 0, float y = 0)
    {
        this.unit = unit;
        float width = 300, height = 20;
        base.Init(_sort, x, y, width, height);
        images.Add(new Image().Init(Path.UI_Background, sort, x, y, width, height));
        images.Add(new Image().Init(Path.UI_Button, sort + 1, x + 10, y + 1, width - 20, height - 2));
        texts.Add(new Text().Init(unit.hp + " / " + unit.max_hp, Color.white, 25, sort + 1, x + 20, y + 60, width));
        return this;
    }
    public void CatchDamageEvent(object sender, DamageEventArgs e) => ChangeValue(e.damage);
    public async void ChangeValue(int dmg)
    {
        if (unit == null) return;
        float playerHp = (float)unit.hp - dmg < 0 ? 0 : (float)unit.hp - dmg;
        float hp = playerHp / (float)unit.max_hp * (images[0].size.x - 20);
        float oldPlayerHp = (float)unit.hp;
        float dir = hp - images[1].size.x;
        for (int i = 0; i < 5; i++)
        {
            images[1].size.x += dir/5;
            oldPlayerHp -= dmg/5;
            if (oldPlayerHp < 0) oldPlayerHp = 0;
            texts[0].ChangeText(oldPlayerHp + " / " + unit.max_hp);
            if (i == 4) 
            {
                images[1].size.x = hp;
                texts[0].ChangeText(playerHp + " / " + unit.max_hp);
            }
            await Task.Delay(1);
        }

        if (Math.Abs(dir) < 1) images[1].pos.x = hp;
        images[1].pos.x = images[0].pos.x + 10;
    }
}