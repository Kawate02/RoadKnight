using System;
using System.Numerics;

public class FieldManager
{
    public Field[,,] field { get; private set; } = new Field[Constant.FieldWidth, Constant.FieldHeight+1, Constant.FieldDepth];
    private Sprite[,] stitches = new Sprite[Constant.FieldWidth, Constant.FieldDepth];

    public void Init()
    {
        for (int i = 0; i < Constant.FieldWidth; i++)
        {
            for (int j = 0; j < Constant.FieldHeight+1; j++)
            {
                for (int k = 0; k < Constant.FieldDepth; k++)
                {
                    field[i, j, k] = new Field().Init(i, j, k);
                }
            }
        }

        for (int i = 0; i < Constant.FieldWidth; i++)
        {
            for (int j = 0; j < Constant.FieldDepth; j++)
            {
                stitches[i, j] = new Sprite().Init(Path.Field, i*Constant.BlockSize, -0.5f*Constant.BlockSize, j*Constant.BlockSize);
                stitches[i, j].Rotate(90, 0, 0);
            }
        }
    }
    public void SetUnit(Unit unit, Vector3 pos)
    {
        if (unit == null) 
        {
            field[(int)pos.x/Constant.BlockSize, (int)pos.y/Constant.BlockSize, (int)pos.z/Constant.BlockSize].SetUnit(null); 
            return; 
        }
        field[(int)pos.x/Constant.BlockSize, (int)pos.y/Constant.BlockSize, (int)pos.z/Constant.BlockSize].SetUnit(unit);
    }
    public void SetBlock(Block block)
    {
        int x = (int)block.pos.x;
        int y = (int)block.pos.y;
        int z = (int)block.pos.z;
        field[x/Constant.BlockSize, y/Constant.BlockSize, z/Constant.BlockSize].SetBlock(block);
    }

    public void RemoveBlock(Vector3 pos)
    {
        field[(int)pos.x/Constant.BlockSize, (int)pos.y/Constant.BlockSize, (int)pos.z/Constant.BlockSize].RemoveBlock();
    }

    public BlockType GetBlock(int x, int y, int z)
    {
        return field[x, y, z].type;
    }
    public bool CanPlace(Vector3 pos)
    {
        if (pos.y < 0 || pos.y > Constant.FieldHeight) return false;
        if (pos.x < 0 || pos.x >= Constant.FieldWidth) return false;
        if (pos.z < 0 || pos.z >= Constant.FieldDepth) return false;
        return field[(int)pos.x, (int)pos.y, (int)pos.z].type == BlockType.Air;
    }
    public bool ThereIsUnit(Vector3 pos)
    {
        if (pos.y <= 0 || pos.y > Constant.FieldHeight) return false;
        if (pos.x < 0 || pos.x >= Constant.FieldWidth) return false;
        if (pos.z < 0 || pos.z >= Constant.FieldDepth) return false;
        return field[(int)pos.x, (int)pos.y, (int)pos.z].unit != null;
    }
    public bool CanGround(Vector3 pos)
    {
        if (pos.y <= 0 || pos.y > Constant.FieldHeight) return false;
        if (pos.x < 0 || pos.x >= Constant.FieldWidth) return false;
        if (pos.z < 0 || pos.z >= Constant.FieldDepth) return false;
        return field[(int)pos.x, (int)pos.y-1, (int)pos.z].type != BlockType.Air;
    }
}