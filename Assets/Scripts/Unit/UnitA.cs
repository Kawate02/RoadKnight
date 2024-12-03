public class UnitA : Unit
{
    new public Unit Init(int x = 0, int y = 0, int z = 0)
    {
        base.Init(x, y, z);
        image += "imagetest";
        return this;
    }

    
}