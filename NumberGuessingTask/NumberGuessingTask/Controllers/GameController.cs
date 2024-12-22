using Microsoft.AspNetCore.Mvc;
using NumberGuessingTask.Core.Interfaces;

namespace NumberGuessingTask.Controllers;

[ApiController]
[Route("api/game")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("start")]
    public async Task<IActionResult> StartNewGameAsync()
        => Ok(await _gameService.StartNewGameAsync());

    [HttpPost("guess/{sessionId}")]
    public async Task<IActionResult> SubmitGuessAsync(Guid sessionId, [FromBody] int guess)
        => Ok(await _gameService.SubmitGuessAsync(sessionId, guess));
}
