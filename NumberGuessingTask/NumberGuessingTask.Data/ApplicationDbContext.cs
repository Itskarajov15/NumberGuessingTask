using Microsoft.EntityFrameworkCore;
using NumberGuessingTask.Data.Entities;

namespace NumberGuessingTask.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<GameSession> GameSessions { get; set; }
}
