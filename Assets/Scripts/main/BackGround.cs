public class BackGround : Object
{
    
    public BackGround Init(int id, float x = 0, float y = 0, float z = 0)
    {
        image = Path.BG_Sky;
        Init(ObjectType.Empty, x, y, z).IdAdjust(id);
        return this;
    }
    public override void OnUpdate()
    {
    }
}