using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.DAL.Models.dic;
using Notes.DAL.Models.rec;
using System.IO;


namespace Notes.DAL
{
    public class NotesContext: DbContext
    {
        //Схема dic 
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }

        //Схема rec
        public DbSet<Definition> Definitions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Note> Notes { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }


        /*
            в конструкторе класса контекста определен вызов метода Database.EnsureCreated(), 
            который при создании контекста автоматически проверит наличие базы данных и, 
            если она отсуствует, создаст ее. Но так как мы используем миграцию, то это методу будет выводить ошибку и вы его
            комментируем.
            Гарантируем, что БД создана
            Database.CanConnect() - Проверка на то что к базе есть подключение
        */

        /*
            DbContextOptionsBuilder: устанавливает параметры подключения
            Для настройки подключения нам надо переопределить метод OnConfiguring. 
            Передаваемый в него параметр класса DbContextOptionsBuilder с помощью метода UseSqlServer 
            позволяет настроить строку подключения для соединения с MS SQL Server. 
            Строка подключения определена в json файле из которой мы забираем подключение и передаем в метод
        */


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .Build();
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //} 



    }

}
