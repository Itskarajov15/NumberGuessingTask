namespace NumberGuessingTask.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Guid id)
        : base($"Game session with Id: {id} was not found.")
    {
    }
}
