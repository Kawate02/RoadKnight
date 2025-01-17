public class Field : Object
{
    public BlockType type { get; private set; }
    Block block;
    public Field Init(float x = 0, float y = 0, float z = 0)
    {
        type = BlockType.Air;
        base.Init(ObjectType.Empty, x, y, z);
        return this;
    }

    public void SetBlock(Block block)
    {
        this.block = block;
        SetType(block.type);
    }
    private void SetType(BlockType type)
    {
        this.type = type;
    }
}