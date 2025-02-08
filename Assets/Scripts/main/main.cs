public class main
{
    Battle battle = new Battle();
    public void Init()
    {
        battle.Init();
    }
    public void OnUpdate()
    {
        //Debug.Log("Empty  : " + EmptyList.GetList().Count + "\nSprite : " + SpriteList.GetList().Count + "\nModel  : " + ModelList.GetList().Count + "\nUI     : " + UIList.GetList().Count + "\nButton : " + ButtonList.GetList().Count + "\nText   : " + TextList.GetList().Count + "\nImage  : " + ImageList.GetList().Count);
        battle.OnUpdate();
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