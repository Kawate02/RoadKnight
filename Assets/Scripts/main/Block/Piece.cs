using System;
using System.Threading.Tasks;

public class Piece : Object
{
    Vector3[] blockPos;
    Block[] blocks;
    public BlockState state { get; protected set; }
    public event System.Action CancelEvent;

    public Piece Init(PieceType type, float x = 0, float y = 0, float z = 0)
    {
        base.Init(ObjectType.Empty, x*Constant.BlockSize, y*Constant.BlockSize, z*Constant.BlockSize);
        switch (type) //typeに対応した組み合わせでブロックを生成
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
                blocks = new Block[5];
                blockPos = new Vector3[5];
                blocks[0] = new BlockB().Init(0, 0, 0);
                blocks[1] = new BlockA().Init(0, 0, 0);
                blocks[2] = new BlockA().Init(0, 0, 0);
                blocks[3] = new BlockA().Init(0, 0, 0);
                blocks[4] = new BlockA().Init(0, 0, 0);
                blockPos[0] = new Vector3(0, 0, 0);
                blockPos[1] = new Vector3(0, 0, 1);
                blockPos[2] = new Vector3(0, 0, 2);
                blockPos[3] = new Vector3(1, 0, 1);
                blockPos[4] = new Vector3(-1, 0, 1);
                break;
            case PieceType.C:
                blocks = new Block[6];
                blockPos = new Vector3[6];
                blocks[0] = new BlockB().Init(0, 0, 0);
                blocks[1] = new BlockA().Init(0, 0, 0);
                blocks[2] = new BlockA().Init(0, 0, 0);
                blocks[3] = new BlockA().Init(0, 0, 0);
                blocks[4] = new BlockA().Init(0, 0, 0);
                blocks[5] = new BlockA().Init(0, 0, 0);
                blockPos[0] = new Vector3(0, 0, 0);
                blockPos[1] = new Vector3(0, 0, 1);
                blockPos[2] = new Vector3(0, 1, 1);
                blockPos[3] = new Vector3(1, 0, 1);
                blockPos[4] = new Vector3(1, 0, 0);
                blockPos[5] = new Vector3(1, 1, 0);
                break;
            case PieceType.D:
                blocks = new Block[13];
                blockPos = new Vector3[13];
                blocks[0] = new BlockB().Init(0, 0, 0);
                blocks[1] = new BlockA().Init(0, 0, 0);
                blocks[2] = new BlockA().Init(0, 0, 0);
                blocks[3] = new BlockA().Init(0, 0, 0);
                blocks[4] = new BlockA().Init(0, 0, 0);
                blocks[5] = new BlockA().Init(0, 0, 0);
                blocks[6] = new BlockA().Init(0, 0, 0);
                blocks[7] = new BlockA().Init(0, 0, 0);
                blocks[8] = new BlockA().Init(0, 0, 0);
                blocks[9] = new BlockA().Init(0, 0, 0);
                blocks[10] = new BlockA().Init(0, 0, 0);
                blocks[11] = new BlockA().Init(0, 0, 0);                
                blocks[12] = new BlockA().Init(0, 0, 0);
                blockPos[0] = new Vector3(0, 0, 0);
                blockPos[1] = new Vector3(-1, 0, 1);
                blockPos[2] = new Vector3(0, 0, 1);
                blockPos[3] = new Vector3(1, 0, 1);
                blockPos[4] = new Vector3(-1, 0, 2);
                blockPos[5] = new Vector3(0, 0, 2);
                blockPos[6] = new Vector3(1, 0, 2);
                blockPos[7] = new Vector3(-1, 1, 2);
                blockPos[8] = new Vector3(0, 1, 2);
                blockPos[9] = new Vector3(1, 1, 2);
                blockPos[10] = new Vector3(-1, 2, 2);
                blockPos[11] = new Vector3(0, 2, 2);
                blockPos[12] = new Vector3(1, 2, 2);
                break;
            case PieceType.E:
                blocks = new Block[10];
                blockPos = new Vector3[10];
                blocks[0] = new BlockB().Init(0, 0, 0);
                blocks[1] = new BlockA().Init(0, 0, 0);
                blocks[2] = new BlockA().Init(0, 0, 0);
                blocks[3] = new BlockA().Init(0, 0, 0);
                blocks[4] = new BlockA().Init(0, 0, 0);
                blocks[5] = new BlockA().Init(0, 0, 0);
                blocks[6] = new BlockA().Init(0, 0, 0);
                blocks[7] = new BlockA().Init(0, 0, 0);
                blocks[8] = new BlockA().Init(0, 0, 0);
                blocks[9] = new BlockA().Init(0, 0, 0);
                blockPos[0] = new Vector3(0, 0, 0);
                blockPos[1] = new Vector3(0, 0, 1);
                blockPos[2] = new Vector3(0, 0, 2);
                blockPos[3] = new Vector3(0, 0, 3);
                blockPos[4] = new Vector3(-1, 0, 1);
                blockPos[5] = new Vector3(-1, 0, 2);
                blockPos[6] = new Vector3(-1, 0, 3);                
                blockPos[7] = new Vector3(1, 0, 1);
                blockPos[8] = new Vector3(1, 0, 2);
                blockPos[9] = new Vector3(1, 0, 3);
                break;
        }

        for (int i = 0; i < blocks.Length; i++)
        {
            blockPos[i].x *= Constant.BlockSize;
            blockPos[i].y *= Constant.BlockSize;
            blockPos[i].z *= Constant.BlockSize;
            blocks[i].SetPos(pos.x + blockPos[i].x, pos.y + blockPos[i].y, pos.z + blockPos[i].z);
        }
        blocks[0].SetScale(0.9f, 0.9f, 0.9f);
        return this;
    }
    public async void Holding()
    {
        state = BlockState.Hold;
        while (state == BlockState.Hold) //ピース保持中の挙動
        {
            if (Input.GetAction(Trigger.Escape).down) 
            {
                Cancel();
                break;
            }
            SetPos(Input.WorldMousePosition.x, Input.WorldMousePosition.y, Input.WorldMousePosition.z); //マウス位置に追従
            if (Input.Scroll != 0)
            {
                //追加キー入力で回転軸を変更する
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
            if (Input.ChoiceBlock != -1) //有効なマスが選択された
            {
                var block = ModelList.GetList()[Input.ChoiceBlock];
                
                bool canPlace = true;
                for (int i = 1; i < blocks.Length; i++)
                {
                    if (!Stage.field.CanPlace((block.pos + blockPos[i])/Constant.BlockSize) || Stage.field.ThereIsUnit((block.pos + blockPos[i])/Constant.BlockSize))
                    {
                        //ピースの一部がフィールド外 or ほかのピースに埋まっている
                        canPlace = false;
                        break;
                    }
                }
                if (canPlace)
                {
                    //選択座標が配置可能である
                    SetPos(block.pos.x, block.pos.y, block.pos.z); //
                    if (Input.GetAction(Trigger.Mouse_Left).down)
                    {
                        ChangeState(BlockState.Set);
                        for (int i = 0; i < blocks.Length; i++)
                        {
                            blocks[i].SetBlock();
                        }
                        TurnEndFlag.EndTurn.Invoke();
                    }
                }
            }
            await Task.Delay(1);
        }
    }
    void Cancel()
    {
        Destroy();
        CancelEvent?.Invoke();
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
    public override void Destroy()
    {
        state = BlockState.Other;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].Destroy();
        }
        base.Destroy();
    }
}
