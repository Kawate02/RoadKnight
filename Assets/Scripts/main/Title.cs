public class Title
{
    UI ui = new UI();
    public void Init() 
    {
        Cam.Init(4, 10, -4, 45, 0, 0);
        ui = new TitleUI().Init();
    }
    public void OnUpdate() 
    {
        if (Input.GetAction(Trigger.Space).down)
        {
            SceneManager.ChangeScene(Scene.Battle);
        }
    }

}

public class TitleUI : UI
{
    public TitleUI Init() 
    {
        images.Add(new Image().Init(Path.Title_BG, 0, 0, 0, 1920, 1080));
        return this;
    }
}