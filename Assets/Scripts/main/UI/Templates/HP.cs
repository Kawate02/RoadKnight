using System.Threading.Tasks;
using UnityEngine;

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
        return this;
    }
    public void ChangeValue()
    {
        if (unit == null) return;
        if (unit.hp <= 0) 
        {
            images[1].size.x = 0;
            return;
        }
        float hp = (float)unit.hp / (float)unit.max_hp * (images[0].size.x - 20);
        float dir = hp - images[1].size.x;
        images[1].size.x += dir;

        if (Mathf.Abs(dir) < 1) images[1].pos.x = hp;
        images[1].pos.x = images[0].pos.x + 10;
    }
}