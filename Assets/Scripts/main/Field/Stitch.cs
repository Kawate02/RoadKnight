public class Stitch : Object
{
    public Stitch Init(float x = 0, float y = 0, float z = 0)
    {
        base.Init(ObjectType.Sprite, x, y, z);
        image = "Visual/Sprite/Field";
        Rotate(90, 0, 0);
        return this;
    }

}