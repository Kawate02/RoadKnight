using System.Collections.Generic;

public class Stage
{
    public static FieldManager field = new FieldManager();
    public static MoveArea moveArea { get; private set; } = new MoveArea();
    public static SkillArea skillArea { get; private set; } = new SkillArea();
    Piece piece;
    List<Block> blocks = new List<Block>();
    
    public void Init()
    {
        Cam.Init(4, 10, -4, 45, 0, 0);
        field.Init();
        for (int i = 0; i < Constant.FieldWidth; i++)
        {
            for (int j = 0; j < Constant.FieldDepth; j++)
            {
                blocks.Add(new BlockA().Init(i, 0, j));
            }
        }
        blocks.Add(new BlockA().Init(4, 1, 4));
        blocks.Add(new BlockA().Init(3, 1, 4));
        blocks.Add(new BlockA().Init(3, 2, 4));
        blocks.Add(new BlockA().Init(2, 3, 4));
        blocks.Add(new BlockA().Init(2, 2, 4));
        blocks.Add(new BlockA().Init(5, 3, 6));
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].SetBlock();
        }
    }
    public void OnUpdate()
    {
    }
    public void Destroy()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].Destroy();
        }
    }
}