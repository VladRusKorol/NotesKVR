using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Notes.BLL.Mappers;
using Notes.BLL.Models.custome;
using Notes.BLL.Models.dic;
using Notes.DAL;
using Notes.DAL.Models.dic;
using static System.Net.Mime.MediaTypeNames;

namespace Notes.BL
{
    public class NotesContextBL
    {
        private readonly NotesContext _notesDB;

        public NotesContextBL() 
        {
            this._notesDB = new NotesContextFactory().CreateDbContext([]);
        }

        public List<AuthorizedAccount> GetAuthorizedAccounts()
        {
            List<AuthorizedAccount> AuthorizedAccounts = [];

            List<DAL.Models.dic.Person> accounts = _notesDB.Persons.ToList();

            foreach (var account in accounts)
            {
                AuthorizedAccounts.Add(Mapper.MapFrom_PersonDAL_To_AuthorizedAccountBLL(account));
            }

            return AuthorizedAccounts;
        }

        public List<UsersInfo> GetUsersInfo()
        {
            List<UsersInfo> UsersInfos = [];

            List<DAL.Models.dic.Person> accounts = _notesDB.Persons.Include(r => r.Role).ToList();

            foreach (var account in accounts)
            {
                UsersInfos.Add(Mapper.MapFrom_PersonDAL_To_UsersInfo(account));
            }

            return UsersInfos;
        }

        public void AddNewPersonStoreProcedure(string firstName, string lastName, string contactName, string emailAdress, string passwordString)
        {
            DAL.Models.dic.Person newPerson = new()
            {
                FirstName = firstName
                , LastName = lastName
                , PhoneNumber = contactName
                , Email = emailAdress
                , Password = passwordString
                , RoleId = 2
            };

            _notesDB.Persons.Add(newPerson);
            _notesDB.SaveChanges();
        }

        public void DeletePersonCascade(int UserId)
        {
            var delPerson = _notesDB.Persons.Find(UserId);

            if (delPerson != null)
            {
                _notesDB.Persons.Remove(delPerson);
                _notesDB.SaveChanges(); 
            }
        }

        public void UpdatePerson(int id, string newFirstName, string newLastName, string newPassword, string newEmailAddress,  string newContactName, string newRole)
        {
            var pers = _notesDB.Persons.Where(p => p.Id == id).ToList(); 

            if (pers[0] != null) { 
                pers[0].FirstName = newFirstName;
                pers[0].LastName = newLastName;
                pers[0].Password = newPassword;
                pers[0].Email = newEmailAddress;
                pers[0].PhoneNumber = newContactName;
                pers[0].RoleId = newRole == "Admin" ? 1 : 2; 
            }
            _notesDB.SaveChanges();
        }

        public int FindByEmail_return_count_users(string email)
        {
            var users = _notesDB.Persons.Where(p => p.Email == email).ToList();
            return users.Count;
        }

        public List<BLL.Models.custome.NoteEmpty> FindByIdPerson_return_PersonNotes(int id)
        {

            /* Запрос получения полной иерархии данных через каскадный запрос
             
            var fullDataPerson =     this._notesDB.Persons.Where(p => p != null && p.Id == id)
                                             .Include(r => r.Role)
                                             .Include(n => n.Notes)
                                             .ThenInclude(d => d.Definitions)
                                             .ThenInclude(i => i.Images)
                                             .ToList();

            */

            /* Проверка что загрузка данных работает в txt файл


            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(p, options);

            using (FileStream fstream = new FileStream("C:\\Users\\Владислав\\Desktop\\Test.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(json);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                Console.WriteLine("Текст записан в файл");
            }
            
             */


            /*  Проходим циклом по количеству персон, но он один так что один проход 
            for (int first_level = 0; first_level < fullDataPerson.Count(); first_level++)
            {
               
                for(int second_level = 0; second_level < fullDataPerson[first_level].Notes.Count(); second_level++)
                {
                   
                    for(int third_level = 0; third_level < fullDataPerson[first_level].Notes.ToList()[second_level].Definitions.Count(); third_level++)
                    {
                       
                        for (int fourth_level = 0; fourth_level < fullDataPerson[first_level].Notes.ToList()[second_level].Definitions.ToList()[third_level].Images.Count(); fourth_level++)
                        {

                        }
                    }

                }
            }
            */

            //Получаем объект персон со связным списком конспектов
            var persons = this._notesDB.Persons.Where(_ => _.Id == id)
                                        .Include(_ => _.Notes)                                
                                        .ToList();

            List<BLL.Models.custome.NoteEmpty> returnNotes = new List<BLL.Models.custome.NoteEmpty>();

            foreach (var person in persons)
            {
                foreach (var item in person.Notes)
                {
                    if(item is not null)
                    {
                        returnNotes.Add(Mapper.MapFor_PersonNoteDefinitionImageDAL_To_NoteBLL(item));
                    }
                    
                }
            }

            return returnNotes; 
        }

        public void AddNote(int UserId, string noteTitle)
        {
            DAL.Models.rec.Note newNote = new DAL.Models.rec.Note { 
                PersonId = UserId, 
                Title = noteTitle,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Definitions = null
            };
            this._notesDB.Notes.Add(newNote);
            this._notesDB.SaveChanges();
        }

        public void DeleteNote(int NoteId)
        {
            var deleteNote = this._notesDB.Notes.Where(_ => _.Id == NoteId).ToList();
            this._notesDB.Notes.Remove(deleteNote[0]);
            this._notesDB.SaveChanges();
        }

        public void EditNote(int NoteId, string newNoteTitle)
        {
            var editNote = this._notesDB.Notes.Where(_ => _.Id == NoteId).ToList();
            if(editNote is not null)
            {
                editNote[0].Title = newNoteTitle;
            }
            this._notesDB.SaveChanges();
        }
    
        public List<BLL.Models.rec.Definition> GetDefinitionsByIdNote(int IdNote)
        {
            List<BLL.Models.rec.Definition> val = this._notesDB.Definitions.Where(_ => _.NoteId == IdNote).Select(item => Mapper.MapFrom_DefinitionDAL_To_DefinitionBLL(item)).ToList();

            return val;
        }
    
        public void EditDefinition(int DefinitionId, string DefinitionTitle, string DefinitionText) 
        {
            var editDef = this._notesDB.Definitions.Where(_ => _.Id == DefinitionId).ToList();
            if(editDef[0] is not null) 
            {
                editDef[0].Title = DefinitionTitle;
                editDef[0].Text = DefinitionText;
            }
            this._notesDB.SaveChanges();
        }

        public void AddDefinition(int DefinintionNoteId, string DefinitionTitle, string DefinitionText)
        {
            DAL.Models.rec.Definition newDefinition = new DAL.Models.rec.Definition { NoteId = DefinintionNoteId, Title = DefinitionTitle, Text = DefinitionText, Images = null };
            this._notesDB.Definitions.Add(newDefinition);
            this._notesDB.SaveChanges();
        }

        public void DelDefinition(int Id)
        {
            var delDef = this._notesDB.Definitions.Where(d => d.Id == Id).ToList();
            this._notesDB.Definitions.Remove(delDef[0]);
            this._notesDB.SaveChanges();
        }

    }

}
