using System.Collections.Generic;

public enum Owner
{
    Player,
    Enemy
}
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
public class Unit : Object
{
    public Owner owner { get; protected set; } = Owner.Player;
    public List<Effect> effects { get; protected set; } = new List<Effect>();
    public List<SkillBase> skills { get; protected set; } = new List<SkillBase>();
    public List<Piece> pieces { get; protected set; } = new List<Piece>();
    public Direction direction { get; protected set; }
    protected float _max_hp = 0;
    protected float _atk = 0;
    protected float _def = 0;
    protected float _spd = 0;
    protected int _move_range = 0;
    public float max_hp { get; protected set; }
    public float hp { get; protected set; }
    public float atk { get; protected set; }
    public float def { get; protected set; }
    public float spd { get; protected set; }
    public int move_range { get; protected set; } = 2;
    public virtual Unit Init(Owner owner, int id, float x = 0, float y = 0, float z = 0)
    {
        image = GetImage(id);
        base.Init(ObjectType.Sprite, Constant.BlockSize * x, Constant.BlockSize * y, Constant.BlockSize * z);
        this.owner = owner;
        if (owner == Owner.Player) direction = Direction.Right;
        if (owner == Owner.Enemy) direction = Direction.Left;
        GetParameter(id);
        ParameterCal();
        Rotate(Cam.rot.x-20, Cam.rot.y, Cam.rot.z);
        skills.Add(new Skill().Init(1));
        skills.Add(new Skill().Init(1));
        skills.Add(new Skill().Init(1));
        Stage.field.SetUnit(this, pos);
        return this;
    }
    public void SetDirection(Direction direction) => this.direction = direction;
    private void GetParameter(int id)
    {
        switch (id)
        {
            case 0:
            name = UnitParameter.Unit01.name;
            _max_hp = UnitParameter.Unit01.max_hp; 
            _atk = UnitParameter.Unit01.atk;
            _def = UnitParameter.Unit01.def;
            _spd = UnitParameter.Unit01.spd;
            _move_range = UnitParameter.Unit01.move_range;
            break;
            case 1:
            name = UnitParameter.Unit02.name;
            _max_hp = UnitParameter.Unit02.max_hp; 
            _atk = UnitParameter.Unit02.atk;
            _def = UnitParameter.Unit02.def;
            _spd = UnitParameter.Unit02.spd;
            _move_range = UnitParameter.Unit02.move_range;
            break;
            case 2:
            name = UnitParameter.Unit03.name;
            _max_hp = UnitParameter.Unit03.max_hp; 
            _atk = UnitParameter.Unit03.atk;
            _def = UnitParameter.Unit03.def;
            _spd = UnitParameter.Unit03.spd;
            _move_range = UnitParameter.Unit03.move_range;
            break;
        }
    }
    private string GetImage(int id)
    {
        switch (id)
        {
            case 0:
            return Path.Sheld_Knocker;
            case 1:
            return Path.Sheld_Knocker;
            case 2:
            return Path.Sheld_Knocker;
            default:
            return "";
        }
    }
    public void ParameterCal()
    {
        var damage = max_hp - hp;
        max_hp = _max_hp;
        atk = _atk;
        def = _def;
        spd = _spd;
        move_range = _move_range;
        for (int i = 0; i < effects.Count; i++) 
        {
            max_hp += _max_hp * effects[i].hp_buff;
            hp = max_hp - damage;
            atk += _atk * effects[i].atk_buff;
            def += _def * effects[i].def_buff;
            spd += _spd * effects[i].spd_buff;
            move_range += effects[i].move_range_buff;
        }
    }

    public virtual void Attack(Unit target)
    {
        target.Damage(atk);
        AttackAction(target);
    }
    public override void Move(float x, float y, float z, float offset = 0)
    {
        Stage.field.SetUnit(null, pos);
        Vector3 toPos = new Vector3(pos.x / Constant.BlockSize + x, pos.y / Constant.BlockSize + y, pos.z / Constant.BlockSize + z);
        for (int i = (int)pos.y; i > 0; i--)
        {
            toPos.y = i;
            if (Stage.moveArea.HasPos(toPos))
            {
                Stage.field.SetUnit(this, toPos*Constant.BlockSize);
                base.Move(toPos*Constant.BlockSize - pos, offset);
                MoveAction();
                return;
            }
        }
    }
    public virtual void Damage(float dmg)
    {
        DamageAction(dmg);
        hp -= dmg;
        if (hp <= 0) 
        {
            hp = 0;
            Dead();
        }
    }
    void Dead()
    {
        DeadAction();
        Destroy();
    }
    public virtual void StartTurnAction() 
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].StartTurnAction(this);
        }
    }
    public virtual void EndTurnAction() 
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].EndTurnAction(this);
        }
    }
    protected virtual void MoveAction()
    {
        Cam.Init(pos.x, Cam.pos.y, pos.z-5, 45, 0, 0);
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].MoveAction(this);
        }
    }
    protected virtual void AttackAction(Unit tardet)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].AttackAction(this, tardet);
        }
    }
    protected virtual void DamageAction(float dmg) 
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].DamageAction(this, dmg);
        }
    }
    protected virtual void DeadAction() 
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].DeadAction(this);
        }
    }
    public void EndFlag(System.Action callback)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].ExeEvent += () => callback();
        }
    }
}