using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Persistence.Context;

public class NotesDbContext : DbContext
{
    public NotesDbContext(DbContextOptions options) : base(options)
    {
            
    }

    public DbSet<Note> Notes { get; set; } 
    public DbSet<Domain.Task> Tasks { get; set; }
    public DbSet<Event> Events { get; set; }
}