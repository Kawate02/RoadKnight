using System.Collections.Generic;

public class Stage
{
    public static FieldManager field = new FieldManager();
    public static MoveArea moveArea { get; private set; } = new MoveArea();
    public static SkillArea skillArea { get; private set; } = new SkillArea();
    public static Piece piece;
    List<Block> blocks = new List<Block>();
    BackGround backGround = new BackGround();
    
    public void Init()
    {
        Cam.Init(4, 10, -4, 45, 0, 0);
        backGround = backGround.Init();
        field.Init();
        for (int i = 0; i < Constant.FieldWidth; i++)
        {
            for (int j = 0; j < Constant.FieldDepth; j++)
            {
                if (i == 0 || i == Constant.FieldWidth - 1) blocks.Add(new BlockA().Init(i, 0, j));
            }
        }
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