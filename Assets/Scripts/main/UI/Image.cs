public class Image : UI
{
    public virtual Image Init(string image, int sort, float x = 0, float y = 0, float width = 0, float height = 0)
    {    
        this.image = image;
        this.sort = sort;
        type = UIType.Image;
        base.Init(type, x, y, width, height);
        return this;
    }
}