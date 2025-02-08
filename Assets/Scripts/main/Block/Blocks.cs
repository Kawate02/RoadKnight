public class BlockA : Block
{
    public override Block Init(float x = 0, float y = 0, float z = 0)
    {
        base.Init(x, y, z);
        image = Path.Block;
        material = Path.WhiteMaterial;
        type = BlockType.Stone;
        return this;
    }
}

public class BlockB : Block
{
    public override Block Init(float x = 0, float y = 0, float z = 0)
    {
        base.Init(x, y, z);
        image = Path.Block;
        material = Path.BlackMaterial;
        type = BlockType.Stone;
        return this;
    }
}