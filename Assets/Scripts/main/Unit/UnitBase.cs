public class Unit : Object
{
    public virtual Unit Init(float x = 0, float y = 0, float z = 0)
    {
        base.Init(ObjectType.Sprite, x, y, z);

        return this;
    }
}