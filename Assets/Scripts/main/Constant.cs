using System.Collections.Generic;

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
        public static int[] skill_id { get; private set; } = { 0, 1, 2 };
        public static PieceType[] pieces { get; private set; } = { PieceType.A, PieceType.B, PieceType.C };
    }
    public class Unit02
    {
        public const string name = "Sheld Knocker";
        public const int max_hp = 1250;
        public const int atk = 300;
        public const int def = 500;
        public const int spd = 200;
        public const int move_range = 2;
        public static int[] skill_id { get; private set; } = { 3, 4, 5 };
        public static PieceType[] pieces { get; private set; } = { PieceType.A, PieceType.B, PieceType.D };
    }
    public class Unit03
    {
        public const string name = "Pega";
        public const int max_hp = 630;
        public const int atk = 350;
        public const int def = 280;
        public const int spd = 430;
        public const int move_range = 4;
        public static int[] skill_id { get; private set; } = { 6, 7, 8 };
        public static PieceType[] pieces { get; private set; } = { PieceType.A, PieceType.B, PieceType.E };
    }
}
public static class SkillDataBase
{
    public class Skill01
    {
        public const string name = "袈裟切り";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0)};
        public const float attack_magnification = 2.0f;
    }
    public class Skill02
    {
        public const string name = "飛空剣";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0),
        new Vector3(2, 1, 0), new Vector3(2, 0, 0), new Vector3(2, -1, 0),
        new Vector3(3, 1, 0), new Vector3(3, 0, 0), new Vector3(3, -1, 0) 
        };
        public const float attack_magnification = 0.9f;
    }
    public class Skill03
    {
        public const string name = "ウォーリィ";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0),
        new Vector3(1, 1, 1), new Vector3(1, 0, 1), new Vector3(1, -1, 1),
        new Vector3(1, 1, -1), new Vector3(1, 0, -1), new Vector3(1, -1, -1),
        new Vector3(2, 1, 0), new Vector3(2, 0, 0), new Vector3(2, -1, 0),
        new Vector3(2, 1, 1), new Vector3(2, 0, 1), new Vector3(2, -1, 1),
        new Vector3(2, 1, -1), new Vector3(2, 0, -1), new Vector3(2, -1, -1)
        };
        public const int attack_count = 4;
        public const float attack_magnification = 0.6f;
    }
    public class Skill04
    {
        public const string name = "ハードアップ";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0)};
        public const int defence_buff_stage = 1;
    }
    public class Skill05
    {
        public const string name = "猪突防進";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0), new Vector3(1, 2, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0), new Vector3(1, -2, 0),
        new Vector3(2, 2, 0), new Vector3(2, 1, 0), new Vector3(2, 0, 0), new Vector3(2, -1, 0), new Vector3(2, -2, 0), 
        new Vector3(3, 2, 0), new Vector3(3, 1, 0), new Vector3(3, 0, 0), new Vector3(3, -1, 0), new Vector3(3, -2, 0)};

        public readonly static List<Vector3> Impact = new List<Vector3>() { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1), new Vector3(1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, 1), new Vector3(-1, 0, -1) };

        public const float attack_magnification = 0.8f;
    }
    public class Skill06
    {
        public const string name = "シールドノック";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0)};
    }
    public class Skill07
    {
        public const string name = "背水";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0)};
        public const int attack_buff_stage = 3;
        public const int defence_debuff_stage = 2;
    }
    public class Skill08
    {
        public const string name = "雷突";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0)};
        public const int attack_count = 3;
        public const float attack_magnification = 0.7f;
    }
    public class Skill09
    {
        public const string name = "ペガ";
        public readonly static List<Vector3> Range = new List<Vector3>() {new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(3, 0, 0), new Vector3(4, 0, 0)};
        public const int max_move_distance = 4;
        public const float attack_magnification = 1.9f;
    }
}
public static class EffectDataBase
{
    public class Effect01
    {
        public const string name = "攻撃力上昇";
        public const int id = 0;
        public const float attack_magnification = 0.25f;
        public const int count = 3;
    }
    public class Effect02
    {
        public const string name = "防御力上昇";
        public const int id = 1;
        public const float defence_magnification = 0.5f;
        public const int count = 3;
    }
    public class Effect03
    {
        public const string name = "攻撃力低下";
        public const int id = 2;
        public const float attack_magnification = -0.25f;
        public const int count = 3;
    }
    public class Effect04
    {
        public const string name = "防御力低下";
        public const int id = 3;
        public const float defence_magnification = -0.5f;
        public const int count = 3;
    }
    public class Effect05
    {
        public const string name = "シールドノック";
        public const int id = 4;
        public const int count = 3;
    }
    public class Effect06
    {
        public const string name = "シールドノックの加護";
        public const int id = 5;
    }
}
public static class Formula
{
    public static int Damage(int owner_atk, int target_def, float attack_magnification = 1.0f)
    {
        int dmg = (int)((owner_atk - target_def) * attack_magnification);
        if (dmg <= 0) dmg = 1;
        return dmg;
    }
}

public static class Path
{
    public const string Wally = "Visual/Sprite/Unit/warry";
    public const string Shield_Knocker = "Visual/Sprite/Unit/shield";
    public const string Pega = "Visual/Sprite/Unit/silk";
    public const string UI_Background = "Visual/Sprite/UI/button_haikei";
    public const string UI_Button = "Visual/Sprite/UI/button";
    public const string UI_ButtonOver = "Visual/Sprite/UI/button_waku";
    public const string UI_Move_Area = "Visual/Sprite/UI/zimen_UI/idouhani";
    public const string UI_Attack_Area = "Visual/Sprite/UI/zimen_UI/kougekihani";
    public const string Title_BG = "Visual/Sprite/sky";

    public const string Field = "Visual/Sprite/Field";
    public const string Sea00 = "Visual/Sprite/BG/sea";
    public const string Sea01 = "Visual/Sprite/BG/sky1";
    public const string Sea02 = "Visual/Sprite/BG/sky1";
    public const string Sea03 = "Visual/Sprite/BG/sky2";
    public const string Sea04 = "Visual/Sprite/BG/sky2";
    public const string Cloud00 = "Visual/Sprite/BG/cloud/bigcloud_enkyori";
    public const string Cloud01 = "Visual/Sprite/BG/cloud/cloud_enkyori";
    public const string Cloud02 = "Visual/Sprite/BG/cloud/cloud_tyukan";
    public const string Cloud03 = "Visual/Sprite/BG/cloud/cloud_tikaku";
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
    B,
    C,
    D,
    E
};

public enum UnitType 
{ 
    A, 
    B 
};

