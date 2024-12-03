public class Unit : Object
{
    public Unit Init(int x = 0, int y = 0, int z = 0)
    {
        base.Init(true, x, y, z);
        image = "Visual/Sprite/Unit/";

        return this;
    }
}