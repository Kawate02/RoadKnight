public enum TurnState
{
    ActionSelecting,
    Viewing
}
public class Turn
{
    Unit[] units = new Unit[6];
    Unit crrentUnit = null;
    UI turnUI = null;
    View view = new View();
    TurnCount turnCount = new TurnCount();
    TurnState state = TurnState.ActionSelecting;
    public void Init(Unit[] units)
    {
        this.units = units;
        SortUnits(units);
        for (int i = 0; i < units.Length; i++) units[i].EndFlag(EndTurn);
        StartTurn(units[0]);
    }
    public void StartTurn(Unit unit)
    {
        crrentUnit = unit;
        turnUI = new UI01().Init(0, crrentUnit, 350, 250);
        Cam.Init(crrentUnit.pos.x, Cam.pos.y, crrentUnit.pos.z-5, 45, 0, 0);
        crrentUnit.StartTurnAction();
        Stage.moveArea.AreaCal(crrentUnit.pos, crrentUnit.move_range);
    }
    public void OnUpdate()
    {
        switch (state)
        {
            case TurnState.ActionSelecting:
                if (Input.GetAction(Trigger.ViewMode).down)
                {
                    ChangeState(TurnState.Viewing);
                }
                if (crrentUnit != null)
                {
                    if (Input.GetAction(Trigger.Move_Left).down) crrentUnit.Move(-1, 0, 0);
                    if (Input.GetAction(Trigger.Move_Right).down) crrentUnit.Move(1, 0, 0);
                    if (Input.GetAction(Trigger.Move_Up).down) crrentUnit.Move(0, 0, 1);
                    if (Input.GetAction(Trigger.Move_Down).down) crrentUnit.Move(0, 0, -1);
                }
                break;
            case TurnState.Viewing:
                if (Input.GetAction(Trigger.ViewMode).down || Input.GetAction(Trigger.Escape).down)
                {
                    ChangeState(TurnState.ActionSelecting);
                }
                view.OnUpdate();
                break;
        }
    }
    void ChangeState(TurnState state)
    {
        this.state = state;
        if (state == TurnState.ActionSelecting)
        {
            view.EndView();
            Cam.Init(crrentUnit.pos.x, Cam.pos.y, crrentUnit.pos.z-5, 45, 0, 0);
            turnUI = new UI01().Init(0, crrentUnit, 350, 250);
            Stage.moveArea.AreaCal(crrentUnit.pos, crrentUnit.move_range);
        }
        else if (state == TurnState.Viewing)
        {
            for (int i = 0; i < crrentUnit.skills.Count; i++) crrentUnit.skills[i].Cancel();
            turnUI.Destroy();
            Stage.moveArea.Destroy();
            view.Init();
        }
    }
    public void EndTurn()
    {
        crrentUnit.EndTurnAction();
        crrentUnit = null;
        turnUI.Destroy();
        StartTurn(units[turnCount.Next()]);
    }
    private void SortUnits(Unit[] units)
    {
        for (int i = 0; i < units.Length; i++)
        {
            for (int j = i + 1; j < units.Length; j++)
            {
                if (units[i].spd < units[j].spd)
                {
                    Unit temp = units[i];
                    units[i] = units[j];
                    units[j] = temp;
                }
            }
        }
    }
}

public class TurnCount
{
    public int turn { get; private set; } = 0;
    public int turnInTurn { get; private set; } = 0;
    public int Next()
    {
        turnInTurn += 1;
        if (turnInTurn == 6)
        {
            turn += 1;
            turnInTurn = 0;
        }
        return turnInTurn;
    }
}