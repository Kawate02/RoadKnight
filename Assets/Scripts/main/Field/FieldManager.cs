using System;

public class FieldManager
{
    private Field[,,] field = new Field[Constant.FieldWidth, Constant.FieldHeight, Constant.FieldDepth];
    private Stitch[,] stitches = new Stitch[Constant.FieldWidth, Constant.FieldDepth];

    public void Init()
    {
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    field[i, j, k] = new Field().Init(i, j, k);
                }
            }
        }

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                stitches[i, j] = new Stitch().Init(i*2, -1, j*2);
            }
        }
    }

    public void SetBlock(int x, int y, int z, Block block)
    {
        field[x/2, y/2, z/2].SetBlock(block);
    }

    public BlockType GetBlock(int x, int y, int z)
    {
        return field[x/2, y/2, z/2].type;
    }
}