
public class main
{
    Battle battle = new Battle();
    public void Init()
    {
        SceneManager.ChangeScene(Scene.Title);
    }
    public void OnUpdate()
    {
        SceneManager.OnUpdate();
        EmptyList.OnUpdate();
        SpriteList.OnUpdate();
        ModelList.OnUpdate();
        UIList.OnUpdate();
        ButtonList.OnUpdate();
        TextList.OnUpdate();
        ImageList.OnUpdate();
    }

    public void Exit()
    {
        SpriteList.GetList().Clear();
        ModelList.GetList().Clear();
        EmptyList.GetList().Clear();
        ButtonList.GetList().Clear();
        TextList.GetList().Clear();
        ImageList.GetList().Clear();
        UIList.GetList().Clear();
    }
}