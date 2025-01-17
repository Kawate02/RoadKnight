public class main
{
    Stage stage = new Stage();
    public void Init()
    {
        stage.Init();
    }
    public void OnUpdate()
    {
        stage.OnUpdate();
        EmptyList.OnUpdate();
        SpriteList.OnUpdate();
        ModelList.OnUpdate();
        UIList.OnUpdate();
        ButtonList.OnUpdate();
        TextList.OnUpdate();
        ImageList.OnUpdate();
    }
}