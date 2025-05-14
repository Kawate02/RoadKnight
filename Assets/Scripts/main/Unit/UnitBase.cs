using System;
using System.Collections.Generic;

public enum Owner
{
    Player,
    Enemy,
    None
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
    public PieceType[] pieces { get; protected set; }
    public Direction direction { get; protected set; }
    protected int _max_hp = 0;
    protected int _atk = 0;
    protected int _def = 0;
    protected int _spd = 0;
    protected int _move_range = 0;
    public int max_hp { get; protected set; }
    public int hp { get; protected set; }
    public int atk { get; protected set; }
    public int def { get; protected set; }
    public int spd { get; protected set; }
    public int move_range { get; protected set; } = 2;
    public int sort;
    private int[] skill_id;
    public EventHandler<DamageEventArgs> DamageEvent;
    public System.Action DeadEvent;
    public virtual Unit Init(Owner owner, int unitid, float x = 0, float y = 0, float z = 0)
    {
        image = GetImage(unitid);
        base.Init(ObjectType.Sprite, Constant.BlockSize * x, Constant.BlockSize * y, Constant.BlockSize * z);
        this.owner = owner;
        if (owner == Owner.Player) SetDirection(Direction.Right);
        if (owner == Owner.Enemy) SetDirection(Direction.Left);
        GetParameter(unitid);
        ParameterCal();
        Rotate(Cam.rot.x, Cam.rot.y, Cam.rot.z);
        Stage.field.SetUnit(this, pos);
        return this;
    }
    public override void OnUpdate()
    {
        Debug.Log(SpriteList.GetList()[id].name);
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].OnUpdate(this);
        }
    }
    public void SetDirection(Direction direction)
    {
        this.direction = direction;
        if (direction == Direction.Right) SetScale(1, 1, 1);
        else if (direction == Direction.Left) SetScale(-1, 1, 1);
    }
    private void GetParameter(int id)
    {
        switch (id)
        {
            //UnitParameterクラスから各種パラメータを取得
            case 0:
            name = UnitParameter.Unit01.name;
            _max_hp = UnitParameter.Unit01.max_hp;
            _atk = UnitParameter.Unit01.atk;
            _def = UnitParameter.Unit01.def;
            _spd = UnitParameter.Unit01.spd;
            _move_range = UnitParameter.Unit01.move_range;
            skill_id = UnitParameter.Unit01.skill_id;
            pieces = UnitParameter.Unit01.pieces;
            break;
            case 1:
            name = UnitParameter.Unit02.name;
            _max_hp = UnitParameter.Unit02.max_hp; 
            _atk = UnitParameter.Unit02.atk;
            _def = UnitParameter.Unit02.def;
            _spd = UnitParameter.Unit02.spd;
            _move_range = UnitParameter.Unit02.move_range;
            skill_id = UnitParameter.Unit02.skill_id;
            pieces = UnitParameter.Unit02.pieces;
            break;
            case 2:
            name = UnitParameter.Unit03.name;
            _max_hp = UnitParameter.Unit03.max_hp; 
            _atk = UnitParameter.Unit03.atk;
            _def = UnitParameter.Unit03.def;
            _spd = UnitParameter.Unit03.spd;
            _move_range = UnitParameter.Unit03.move_range;
            skill_id = UnitParameter.Unit03.skill_id;
            pieces = UnitParameter.Unit03.pieces;
            break;
        }
        for (int i = 0; i < skill_id.Length; i++)
        {
            skills.Add(new Skill().Init(skill_id[i]));
        }
    }
    private string GetImage(int id)
    {
        switch (id)
        {
            case 0:
            return Path.Wally;
            case 1:
            return Path.Shield_Knocker;
            case 2:
            return Path.Pega;
            default:
            return "";
        }
    }
    public void ParameterCal() //バフ適用時などに最終パラメータを計算し直す
    {
        var damage = max_hp - hp;
        max_hp = _max_hp;
        hp = max_hp - damage;
        atk = _atk;
        def = _def;
        spd = _spd;
        move_range = _move_range;
        for (int i = 0; i < effects.Count; i++) 
        {
            max_hp = max_hp + (int)(_max_hp * effects[i].hp_buff) < 0 ? 0 : max_hp + (int)(_max_hp * effects[i].hp_buff);
            hp = max_hp - damage;
            atk = atk + (int)(_atk * effects[i].atk_buff) < 0 ? 0 : atk + (int)(_atk * effects[i].atk_buff);
            def = def + (int)(_def * effects[i].def_buff) < 0 ? 0 : def + (int)(_def * effects[i].def_buff);
            spd = spd + (int)(_spd * effects[i].spd_buff) < 0 ? 0 : spd + (int)(_spd * effects[i].spd_buff);
            move_range = move_range + effects[i].move_range_buff < 0 ? 0 : move_range + effects[i].move_range_buff;
        }
    }
    //通常攻撃コマンドが無いため不使用///////////////////////
    public virtual void Attack(Unit target)
    {
        target.Damage(atk);
        AttackAction(target);
    }
    ///////////////////////////////////////////////////////

    //offsetフレームかけて現在地から目標座標まで移動する
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
    public override void SetPos(float x, float y, float z)
    {
        Stage.field.SetUnit(null, pos);
        base.SetPos(x, y, z);
        Stage.field.SetUnit(this, pos);
    }
    public bool HasEffect(Effect effect) 
    { 
        for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].id == effect.id) return true;
        }
        return false;
    }
    public virtual void Damage(int dmg) //ダメージ計算後の値が渡される
    {
        if (hp <= 0) return;
        DamageAction(ref dmg);
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

    //各アクションに連動する効果があれば実行する//////////////////////////////////////////////////////////
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
    protected virtual void DamageAction(ref int dmg) 
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].DamageAction(this, ref dmg);
        }
        DamageEvent?.Invoke(this, new DamageEventArgs(dmg)); //HPバー減少などのイベントが紐づけられている
    }
    protected virtual void DeadAction() 
    {
        DeadEvent?.Invoke(); //Turnクラスの行動順管理配列から自身を削除
        Stage.field.SetUnit(null, pos); //ユニットを非表示にする
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].DeadAction(this);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public bool IsEnemy(Unit target) { return target.owner != owner; }
    public void AddEffect(Effect effect) 
    { 
        effects.Add(effect); 
        effect.Init(this);
        ParameterCal();
    }
    public void RemoveEffect(Effect effect) 
    { 
        effects.Remove(effect);
        ParameterCal();
    }
}
public class DamageEventArgs : EventArgs
    {
        public DamageEventArgs(int damage) :base()
        { this.damage = damage; }
        public int damage;
    }
