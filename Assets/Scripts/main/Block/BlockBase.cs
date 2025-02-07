public enum BlockState
{
    Other,
    Set,
    Hold
}
public class Block : Object
{
    public BlockType type { get; protected set; }
    public BlockState state { get; protected set; }

    public virtual Block Init(float x = 0, float y = 0, float z = 0)
    {
        base.Init(ObjectType.Model, x*Constant.BlockSize, y*Constant.BlockSize, z*Constant.BlockSize);
        state = BlockState.Other;
        return this;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (state == BlockState.Set && collisonSize.x != 2)
        {
            collisonSize = new Vector3(Constant.BlockSize, Constant.BlockSize, Constant.BlockSize);
        }
        else if (state != BlockState.Set && collisonSize.x != 0)
        {
            collisonSize = new Vector3(0, 0, 0);
        }
    }
    public virtual void SetBlock()
    {
        var x = pos.x;
        var y = pos.y;
        var z = pos.z;
        SetPos(x, y, z);
        state = BlockState.Set;
        Stage.field.SetBlock(this);
    }

    public void ChangeState(BlockState state)
    {
        this.state = state;
    }
}