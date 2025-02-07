using System;

public class Piece : Object
{
    Vector3[] blockPos;
    Block[] blocks;
    public BlockState state { get; protected set; }

    public Piece Init(PieceType type, float x = 0, float y = 0, float z = 0)
    {
        base.Init(ObjectType.Empty, x*Constant.BlockSize, y*Constant.BlockSize, z*Constant.BlockSize);
        switch (type)
        {
            case PieceType.A:
                blocks = new Block[4];
                blockPos = new Vector3[4];
                blocks[0] = new BlockB().Init(0, 0, 0);
                blocks[1] = new BlockA().Init(0, 0, 0);
                blocks[2] = new BlockA().Init(0, 0, 0);
                blocks[3] = new BlockA().Init(0, 0, 0);
                blockPos[0] = new Vector3(0, 0, 0);
                blockPos[1] = new Vector3(1, 0, 0);
                blockPos[2] = new Vector3(2, 0, 0);
                blockPos[3] = new Vector3(2, 1, 0);
                break;
            case PieceType.B:
                
                break;
        }

        for (int i = 0; i < blocks.Length; i++)
        {
            blockPos[i].x *= Constant.BlockSize;
            blockPos[i].y *= Constant.BlockSize;
            blockPos[i].z *= Constant.BlockSize;
            blocks[i].SetPos(pos.x + blockPos[i].x, pos.y + blockPos[i].y, pos.z + blockPos[i].z);
        }
        blocks[0].Scale(-0.1f, -0.1f, -0.1f);


        return this;
    }

    public override void OnUpdate()
    {
        if (state == BlockState.Hold)
        {
            SetPos(Input.WorldMousePosition.x, Input.WorldMousePosition.y, Input.WorldMousePosition.z);
            if (Input.Scroll != 0)
            {
                if  (Input.GetAction(Trigger.Rotate_X).value)
                {
                    Rotate(Input.Scroll, 0, 0);
                }
                else if (Input.GetAction(Trigger.Rotate_Y).value)
                {
                    Rotate(0, Input.Scroll, 0);
                }
                else if (Input.GetAction(Trigger.Rotate_Z).value)
                {
                    Rotate(0, 0, Input.Scroll);
                }
            }
            if (Input.ChoiceBlock != -1)
            {
                var block = ModelList.GetList()[Input.ChoiceBlock];
                
                bool canPlace = true;
                for (int i = 1; i < blocks.Length; i++)
                {
                    if (block.pos.x + blockPos[i].x >= Constant.FieldWidth*2 || block.pos.y + blockPos[i].y >= Constant.FieldHeight*2 || block.pos.z + blockPos[i].z >= Constant.FieldDepth*2 
                    || block.pos.x + blockPos[i].x < 0 || block.pos.y + blockPos[i].y < 0 || block.pos.z + blockPos[i].z < 0)
                    {
                        canPlace = false;
                        break;
                    }
                    if (Stage.field.GetBlock((int)(block.pos.x + blockPos[i].x)/Constant.BlockSize, (int)(block.pos.y + blockPos[i].y)/Constant.BlockSize, (int)(block.pos.z + blockPos[i].z)/Constant.BlockSize) != BlockType.Air)
                    {
                    
                        canPlace = false;
                        break;
                    }
                }
                if (canPlace)
                {
                    SetPos(block.pos.x, block.pos.y, block.pos.z);
                    if (Input.GetAction(Trigger.Mouse_Left).down)
                    {
                        ChangeState(BlockState.Set);
                        for (int i = 0; i < blocks.Length; i++)
                        {
                            blocks[i].SetBlock();
                        }
                    }
                }
            }
        }
    }

    public override void Move(float x, float y, float z, float offset = 0)
    {
        pos.x += x;
        pos.y += y;
        pos.z += z;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].SetPos(pos.x + blockPos[i].x, pos.y + blockPos[i].y, pos.z + blockPos[i].z);
        }
    }
    public override void SetPos(float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].SetPos(pos.x + blockPos[i].x, pos.y + blockPos[i].y, pos.z + blockPos[i].z);
        }
    }
    public override void Rotate(float x, float y, float z, float offset = 0)
    {
        
        for (int i = 1; i < blockPos.Length; i++)
        {
            Vector3 temp = blockPos[i];
            if (x != 0) 
            {
                double ny, nz;
                nz = (temp.z * 0 - temp.y * 1)*x;
                ny = (temp.z * 1 + temp.y * 0)*x;
                blockPos[i] = new Vector3(temp.x, (float)ny, (float)nz);
            }
            if (y != 0)
            {
                double nx, nz;
                nz = (temp.z * 0 - temp.x * 1)*y;
                nx = (temp.z * 1 + temp.x * 0)*y;
                blockPos[i] = new Vector3((float)nx, temp.y, (float)nz);
            }
            if (z != 0)
            {
                double nx, ny;
                ny = (temp.y * 0 - temp.x * 1)*z;
                nx = (temp.y * 1 + temp.x * 0)*z;
                blockPos[i] = new Vector3((float)nx, (float)ny, temp.z);
            }
            blocks[i].SetPos(pos.x + blockPos[i].x, pos.y + blockPos[i].y, pos.z + blockPos[i].z);
        }
    }
    public void ChangeState(BlockState state)
    {
        this.state = state;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].ChangeState(state);
        }
    }
}