public class Field : Object
{
    public BlockType type { get; private set; }
    public Unit unit { get; private set; } = null;
    Block block;
    public Field Init(float x = 0, float y = 0, float z = 0)
    {
        type = BlockType.Air;
        base.Init(ObjectType.Empty, x, y, z);
        return this;
    }
    public void SetUnit(Unit owner)
    {
        this.unit = owner;
    }

    public void SetBlock(Block block)
    {
        this.block = block;
        SetType(block.type);
    }
    public void RemoveBlock()
    {
        SetType(BlockType.Air);
    }
    private void SetType(BlockType type)
    {
        Debug.Log(pos.ToString() + " " + type);
        this.type = type;
    }
}