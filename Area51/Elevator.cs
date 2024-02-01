namespace Area51;

public interface IElevator
{
    public void GoToLevel(Floor floor, IAgent agent);
    public void CallElevator(Floor floor);
}

public class Elevator : IElevator
{
    private bool _isDisabled = false;
    private int _currentLevel = 0;

    public void GoToLevel(Floor floor, IAgent agent)
    {
        if (_isDisabled)
        {
            Console.WriteLine();
            return;
        }

        _isDisabled = true;

        MoveElevator(floor);
        OpenDoor(agent, floor);

        _isDisabled = false;
    }

    public void CallElevator(Floor floor)
    {
        MoveElevator(floor);
    }

    private static void OpenDoor(IAgent agent, Floor floor)
    {
        switch (agent, floor)
        {
            case (Confidential, Floor.Ground):
                Console.WriteLine($"{agent} enters {floor} floor");
                break;
            case (Secret, Floor.Nuclear):
                Console.WriteLine($"{agent} enters {floor} floor");
                break;
            case (TopSecret, Floor.Alien):
                Console.WriteLine($"{agent} enters {floor} floor");
                break;
            case (TopSecret, Floor.Experimental):
                Console.WriteLine($"{agent} enters {floor} floor");
                break;
            default:
                Console.WriteLine($"{agent} cannot go to {floor} floor");
                break;
        }
    }

    private void MoveElevator(Floor floor)
    {
        if ((int)floor == _currentLevel)
        {
            return;
        }

        for (; (int)floor >= _currentLevel;)
        {
            Thread.Sleep(1000);
            _currentLevel++;
            Console.WriteLine($"Moved to floor {(Floor)_currentLevel}");
        }
    }
}