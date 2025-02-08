public static class Constant
{
    public const int FieldWidth = 16;
    public const int FieldHeight = 4;
    public const int FieldDepth = 8;
    public const int BlockSize = 2;
    public const int ScreenWidth = 1920;
    public const int ScreenHeight = 1080;
}

public static class UnitParameter
{
    public class Unit01
    {
        public const string name = "Wally";
        public const int max_hp = 800;
        public const int atk = 500;
        public const int def = 350;
        public const int spd = 346;
        public const int move_range = 2;
    }
    public class Unit02
    {
        public const string name = "Sheld Knocker";
        public const int max_hp = 1250;
        public const int atk = 300;
        public const int def = 500;
        public const int spd = 200;
        public const int move_range = 2;
    }
    public class Unit03
    {
        public const string name = "Pega";
        public const int max_hp = 630;
        public const int atk = 600;
        public const int def = 280;
        public const int spd = 430;
        public const int move_range = 4;
    }
}
public static class SkillDataBase
{
    public class Skill01
    {
        public const float attack_magnification = 2.0f;
    }
}
public static class Formula
{
    public static int Damage(int owner_atk, int target_def)
    {
        int dmg = owner_atk - target_def;
        return dmg;
    }
}

public static class Path
{
    public const string Sheld_Knocker = "Visual/Sprite/Unit/doorknight";
    public const string UI_Background = "Visual/Sprite/UI/button_haikei";
    public const string UI_Button = "Visual/Sprite/UI/button";
    public const string UI_ButtonOver = "Visual/Sprite/UI/button_waku";
    public const string UI_Move_Area = "Visual/Sprite/UI/zimen_UI/idouhani";
    public const string UI_Attack_Area = "Visual/Sprite/UI/zimen_UI/kougekihani";

    public static string Field = "Visual/Sprite/Field";
    public static string BG_Sky = "Visual/Sprite/sky";

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

