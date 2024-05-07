using Microsoft.EntityFrameworkCore;
using Notes.DAL_SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL_SQLite
{
    public class NotesContext : DbContext
    {
        public DbSet<Definition> Definitions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Note> Notes { get; set; }

        public NotesContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=notes.db");
        }
    }
}
