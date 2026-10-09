public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted = _amountCompleted + 1;

        if (_amountCompleted == _target)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string statusSymbol = " ";
        if (IsComplete())
        {
            statusSymbol = "X";
        }

        return "[" + statusSymbol + "] " + GetName() + " (" + GetDescription() + ") -- Currently completed: " + _amountCompleted + "/" + _target;
    }

    public override string GetStringRepresentation()
    {
        return "ChecklistGoal:" + GetName() + "," + GetDescription() + "," + GetPoints() + "," + _bonus + "," + _target + "," + _amountCompleted;
    }
}