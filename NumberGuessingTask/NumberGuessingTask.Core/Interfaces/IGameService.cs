using NumberGuessingTask.Core.Models;
using NumberGuessingTask.Data.Entities;

namespace NumberGuessingTask.Core.Interfaces;

public interface IGameService
{
    Task<GameSession> StartNewGameAsync();

    Task<GuessResponse> SubmitGuessAsync(Guid sessionId, int guess);
}
