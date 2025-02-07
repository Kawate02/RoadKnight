public class Parameter
{
    public Parameter(float value) => this.value = value;
    private float _value = 0;
    public float value
    {
        get => _value;
        set => _value = value;
    }
}