public static class Constant
{
    public const int FieldWidth = 16;
    public const int FieldHeight = 4;
    public const int FieldDepth = 8;
}

public static class Path
{
    public const string Unit01 = "Visual/Sprite/Unit/doorknight";

    public const string Block = "Visual/Model/Block/Block";
    public const string BlackMaterial = "Visual/Model/Block/Material/Black";
    public const string WhiteMaterial = "Visual/Model/Block/Material/White";
}

public enum BlockType
{ 
    Air, 
    Stone 
};

public enum PieceType 
{ 
    A, 
    B 
};

public enum UnitType 
{ 
    A, 
    B 
};

