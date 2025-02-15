using System.Collections.Generic;

public class BackGround : Object
{
    Sprite[] sea = new Sprite[5];
    Sprite[] sky = new Sprite[4];
    List<Cloud> clouds = new List<Cloud>();
    public BackGround Init(float x = 0, float y = 0, float z = 0)
    {
        Init(ObjectType.Sprite, x, y, z).IdAdjust(id);

        sea[0] = new Sprite().Init(Path.Sea00, 0, -5, 0);
        sea[0].Rotate(90, 0, 0);
        sea[1] = new Sprite().Init(Path.Sea01, 0, 0, 5);
        sea[2] = new Sprite().Init(Path.Sea02, 0, 0, -5);
        sea[3] = new Sprite().Init(Path.Sea03, 9, 0, 0);
        sea[4] = new Sprite().Init(Path.Sea04, -9, 0, 0);
        sea[3].Rotate(0, 90, 0);
        sea[4].Rotate(0, 90, 0);
        for (int i = 0; i < sea.Length; i++)
        {
            sea[i].SetScale(5f, 5f, 5f);
            sea[i].SetPos(sea[i].pos.x * 5, sea[i].pos.y * 5, sea[i].pos.z * 5);
        }

        clouds.Add(new Cloud().Init(0, 0, -20, 0));
        clouds.Add(new Cloud().Init(1, 0, -15, 0));
        clouds.Add(new Cloud().Init(2, 0, -10, 0));
        clouds.Add(new Cloud().Init(3, 0, -5, 0));
        return this;
    }
}

public class Cloud : Sprite
{
    float speed = 0.1f;
    public Cloud Init(int id, float x = 0, float y = 0, float z = 0)
    {
        this.id = id;
        switch (id)
        {
            case 0: 
                image = Path.Cloud00; 
                speed = 0.01f;
                break;
            case 1: 
                image = Path.Cloud01;
                speed = 0.05f;
                break;
            case 2: 
                image = Path.Cloud02;
                speed = 0.06f;
                break;
            case 3: 
                image = Path.Cloud03;
                speed = 0.06f;
                break;
        }
        Init(image, x, y, z);
        Rotate(45, 0, 0);
        SetScale(5f, 5f, 5f);
        return this;
    }
    public override void OnUpdate()
    {
        Move(speed, 0, 0);
        if (pos.x > 70) pos.x = -70;
    }
}