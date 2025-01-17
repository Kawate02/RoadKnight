public class Stage
{
    public static FieldManager field = new FieldManager();
    Piece piece1;
    Block[]blocks = new Block[4]; 
    Button button = new Button();
    Unit unit = new Unit01();
    public void Init()
    {
        Cam.Init(4, 10, -4, 45, 0, 0);
        field.Init();
        piece1 = new Piece().Init(PieceType.A);
        piece1.ChangeState(BlockState.Set);
        blocks[0] = new BlockA().Init(0, 0, 0);
        blocks[1] = new BlockA().Init(1, 0, 0);
        blocks[2] = new BlockA().Init(0, 0, 7);
        blocks[3] = new BlockA().Init(3, 0, 0);
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].SetBlock();
        }
        button.Init(0, 0, 0, 200, 200);
        unit.Init(0, 2, 0);
    }
    public void OnUpdate()
    {
        if (Input.GetAction(Trigger.Mouse_Right).down)
        {
            Piece piece = new Piece().Init(PieceType.A);
            piece.ChangeState(BlockState.Hold);
        }
    }
}