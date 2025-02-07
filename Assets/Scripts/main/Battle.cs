public class Battle
{
    Unit[] units = new Unit[6];
    Stage stage = new Stage();
    Turn turn = new Turn();
    public void Init()
    {
        stage.Init();
        units[0] = new Unit().Init(Owner.Player,0, 5, 1, 0);
        units[1] = new Unit().Init(Owner.Player,1, 5, 1, 1);
        units[2] = new Unit().Init(Owner.Player,2, 5, 1, 2);
        units[3] = new Unit().Init(Owner.Enemy,0, 5, 1, 3);
        units[4] = new Unit().Init(Owner.Enemy,1, 5, 1, 4);
        units[5] = new Unit().Init(Owner.Enemy,2, 5, 1, 5);
        turn.Init(units);
    }
    public void StartBattle()
    {
        
    }
    public void OnUpdate()
    {
        stage.OnUpdate();
        turn.OnUpdate();
    }
    public void EndBattle()
    {
        stage.Destroy();
    }
}