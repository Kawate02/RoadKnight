using System;

public class Battle
{
    Unit[] units = new Unit[6];
    Stage stage = new Stage();
    Turn turn = new Turn();
    UI05[] playerUI = new UI05[6];
    public void Init()
    {
        stage.Init();
        units[0] = new Unit().Init(Owner.Player,0, 0, 1, 2);
        units[1] = new Unit().Init(Owner.Player,1, 0, 1, 4);
        units[2] = new Unit().Init(Owner.Player,2, 0, 1, 6);
        units[3] = new Unit().Init(Owner.Enemy,0, Constant.FieldWidth - 1, 1, 2);
        units[4] = new Unit().Init(Owner.Enemy,1, Constant.FieldWidth - 1, 1, 4);
        units[5] = new Unit().Init(Owner.Enemy,2, Constant.FieldWidth - 1, 1, 6);

        playerUI[0] = new UI05().Init(0, units[0], 10, Constant.ScreenHeight - 200);
        units[0].DamageEvent += playerUI[0].hp.CatchDamageEvent;

        playerUI[1] = new UI05().Init(1, units[1], 10, Constant.ScreenHeight - 350);
        units[1].DamageEvent += playerUI[1].hp.CatchDamageEvent;

        playerUI[2] = new UI05().Init(2, units[2], 10, Constant.ScreenHeight - 500);
        units[2].DamageEvent += playerUI[2].hp.CatchDamageEvent;

        playerUI[3] = new UI05().Init(3, units[3], Constant.ScreenWidth - 410, Constant.ScreenHeight - 200);
        units[3].DamageEvent += playerUI[3].hp.CatchDamageEvent;

        playerUI[4] = new UI05().Init(4, units[4], Constant.ScreenWidth - 410, Constant.ScreenHeight - 350);
        units[4].DamageEvent += playerUI[4].hp.CatchDamageEvent;

        playerUI[5] = new UI05().Init(5, units[5], Constant.ScreenWidth - 410, Constant.ScreenHeight - 500);
        units[5].DamageEvent += playerUI[5].hp.CatchDamageEvent;
        turn.Init(units);
        turn.EndBattle += EndBattle;
    }
    public void StartBattle()
    {
        
    }
    public void OnUpdate()
    {
        if (Input.GetAction(Trigger.Space).down)
        {
            SceneManager.ChangeScene(Scene.Title);
        }
        stage.OnUpdate();
        turn.OnUpdate();
    }
    public void EndBattle(object sender, EventArgs e)
    {
        stage.Destroy();
    }
}