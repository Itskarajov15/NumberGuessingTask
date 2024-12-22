namespace NumberGuessingTask.Core.Models;

public class GuessResponse
{
    public string Message { get; set; } = string.Empty;

    public List<int> Attempts { get; set; } = new();
}
