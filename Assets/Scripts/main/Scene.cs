using System.Threading.Tasks;

public enum Scene
{
    Title,
    Battle
}

public class SceneManager
{
    static Scene scene;
    static Battle battle = new Battle();
    static Title title = new Title();

    public static void OnUpdate()
    {
        switch (scene)
        {
            case Scene.Title:
                title.OnUpdate();
                break;
            case Scene.Battle:
                battle.OnUpdate();
                break;
            default:
                break;
        }
    }

    public void Init() 
    {
        ChangeScene(Scene.Title);
    }
    public Scene GetScene() => scene;

    public async static void ChangeScene(Scene nextScene)
    {
        await Task.Delay(1);
        SpriteList.GetList().Clear();
        ModelList.GetList().Clear();
        EmptyList.GetList().Clear();
        ButtonList.GetList().Clear();
        TextList.GetList().Clear();
        ImageList.GetList().Clear();
        UIList.GetList().Clear();
        switch (nextScene)
        {
            case Scene.Title:
                title.Init();
                break;
            case Scene.Battle:
                battle.Init();
                break;
        }
        scene = nextScene;
    }
}