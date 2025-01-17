public class Unit01 : Unit
{
    public override Unit Init(float x = 0, float y = 0, float z = 0)
    {
        base.Init(x, y, z);
        image = Path.Unit01;
        return this;
    }

    public override void OnUpdate()
    {
        
    }
}