using NumberGuessingTask.Core.Exceptions;
using NumberGuessingTask.Core.Interfaces;
using NumberGuessingTask.Core.Models;
using NumberGuessingTask.Data;
using NumberGuessingTask.Data.Entities;

namespace NumberGuessingTask.Core.Implementations;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GameSession> StartNewGameAsync()
    {
        GameSession gameSession = new GameSession
        {
            Id = Guid.NewGuid(),
            TargetNumber = GenerateRandomNumber(),
            IsCompleted = false
        };

        await _context.GameSessions.AddAsync(gameSession);
        await _context.SaveChangesAsync();

        return gameSession;
    }

    public async Task<GuessResponse> SubmitGuessAsync(Guid sessionId, int guess)
    {
        GameSession? gameSession = await _context.GameSessions.FindAsync(sessionId);

        if (gameSession is null)
        {
            throw new NotFoundException(sessionId);
        }

        if (gameSession.IsCompleted)
        {
            throw new GameCompletedException();
        }

        gameSession.Attempts.Add(guess);

        if (guess == gameSession.TargetNumber)
        {
            gameSession.IsCompleted = true;

            await _context.SaveChangesAsync();

            return new GuessResponse
            {
                Message = "Congratulations! You guessed the correct number.",
                Attempts = gameSession.Attempts
            };
        }

        if (gameSession.Attempts.Count() >= 3)
        {
            gameSession.IsCompleted = true;

            await _context.SaveChangesAsync();

            return new GuessResponse
            {
                Message = "Game over! You have used all attempts.",
                Attempts = gameSession.Attempts
            };
        }

        await _context.SaveChangesAsync();

        return new GuessResponse
        {
            Message = "Try again!",
            Attempts = gameSession.Attempts
        };
    }

    private int GenerateRandomNumber()
        => new Random().Next(1, 101);
}
