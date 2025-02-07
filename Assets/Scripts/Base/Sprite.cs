public class Sprite : Object
{
    public Sprite Init(string path, float x, float y, float z)
    {
        image = path;
        base.Init(ObjectType.Sprite, x, y, z);
        return this;
    }
}