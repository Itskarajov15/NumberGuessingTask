namespace NumberGuessingTask.Core.Exceptions;

public class GameCompletedException : Exception
{
    public GameCompletedException()
        : base("Game is already completed.")
    {
    }
}
