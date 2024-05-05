using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.DAL.Models.dic;
using Notes.DAL.Models.rec;
using System.IO;


namespace Notes.DAL
{
    public class NotesContext: DbContext
    {
        //����� dic 
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }

        //����� rec
        public DbSet<Definition> Definitions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Note> Notes { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }


        /*
            � ������������ ������ ��������� ��������� ����� ������ Database.EnsureCreated(), 
            ������� ��� �������� ��������� ������������� �������� ������� ���� ������ �, 
            ���� ��� ����������, ������� ��. �� ��� ��� �� ���������� ��������, �� ��� ������ ����� �������� ������ � �� ���
            ������������.
            �����������, ��� �� �������
            Database.CanConnect() - �������� �� �� ��� � ���� ���� �����������
        */

        /*
            DbContextOptionsBuilder: ������������� ��������� �����������
            ��� ��������� ����������� ��� ���� �������������� ����� OnConfiguring. 
            ������������ � ���� �������� ������ DbContextOptionsBuilder � ������� ������ UseSqlServer 
            ��������� ��������� ������ ����������� ��� ���������� � MS SQL Server. 
            ������ ����������� ���������� � json ����� �� ������� �� �������� ����������� � �������� � �����
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
