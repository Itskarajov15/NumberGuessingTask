namespace NumberGuessingTask.Data.Entities;

public class GameSession
{
    public Guid Id { get; set; }

    public int TargetNumber { get; set; }

    public List<int> Attempts { get; set; } = new();

    public bool IsCompleted { get; set; }
}
