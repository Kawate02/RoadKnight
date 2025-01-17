public class UIBase : UI
{
    public virtual UIBase Init(int sort, float x = 0, float y = 0, float width = 0, float height = 0)
    {
        this.sort = sort;
        type = UIType.Text;
        base.Init(type, x, y, width, height);
        return this;
    }
}