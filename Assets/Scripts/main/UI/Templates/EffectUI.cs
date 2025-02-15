using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class UI08 : UI
{
    Unit unit;
    List<Effect> effects = new List<Effect>();
    int effectCount = 0;
    UI09[] icons = new UI09[0];
    public UI08 Init(int _sort, Unit unit, float x = 0, float y = 0)
    {
        this.unit = unit;
        effects = new List<Effect>(unit.effects);
        float width = 300, height = 20;
        base.Init(_sort, x, y, width, height);
        return this;
    }
    public override void OnUpdate()
    {
        if (effects.Count != unit.effects.Count)
        {
            UIUpdate();
        }
        effects = new List<Effect>(unit.effects);
    }
    void UIUpdate()
    {
        Reset();
        List<int> ids = new List<int>();
        for (int i = 0; i < unit.effects.Count; i++)
        {
            if (ids.Contains(unit.effects[i].id))
            {
                icons[unit.effects[i].id].ChangeValue(icons[unit.effects[i].id].count + 1);
            }
            else
            {
                ids.Add(unit.effects[i].id);
                if (icons.Length <= unit.effects[i].id) Array.Resize(ref icons, unit.effects[i].id + 1);
                icons[unit.effects[i].id] = new UI09().Init(sort, unit, unit.effects[i].id, pos.x + effectCount * 25, pos.y);
                effectCount++;
            }
        }
    }
    void Reset()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i]?.Destroy();
        }
        icons = new UI09[0];
        effectCount = 0;
    }
}

public class UI09 : UI
{
    Unit unit;
    public int count { get; private set; } = 1;
    public UI09 Init(int _sort, Unit unit, int id, float x = 0, float y = 0)
    {
        this.unit = unit;
        float width = 20, height = 20;
        base.Init(_sort, x, y, width, height);
        images.Add(new Image().Init(Path.UI_Button, sort, x, y, width, height));
        texts.Add(new Text().Init(count.ToString(), Color.black, 20, sort + 1, x + 19, y, width));
        return this;
    }
    public void ChangeValue(int value)
    {
        texts[0].ChangeText(value.ToString());
        count = value;
    }
}