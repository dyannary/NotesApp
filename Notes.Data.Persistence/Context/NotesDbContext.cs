using Microsoft.EntityFrameworkCore;
using Notes.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Persistence.Context
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; } 
    }
}
