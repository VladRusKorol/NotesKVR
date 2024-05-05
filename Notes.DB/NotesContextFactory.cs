using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Notes.DAL
{
    public class NotesContextFactory : IDesignTimeDbContextFactory<NotesContext>
    {
        public NotesContextFactory() { }

        public NotesContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<NotesContext>();

            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .Build();

            optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new NotesContext(optionBuilder.Options);
        }
    }
}
