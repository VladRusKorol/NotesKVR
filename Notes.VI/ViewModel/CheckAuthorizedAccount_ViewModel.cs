
using Microsoft.EntityFrameworkCore;
using Notes.APL.Common;
using Notes.APL.Model;
using Notes.APL.View.Windows.CheckAuthorizedAccount_View;
using Notes.BL;
using Notes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.APL.ViewModel
{
    public class CheckAuthorizedAccount_ViewModel: BaseINPC
    {
        //VIEW MODEL CONTEXT
        private NotesContextBL _context = new NotesContextBL();





        //VIEW MODEL VARIABLES
        private string _authorizationResult;
        public string AuthorizationResult
        {
            get => this._authorizationResult;
            set => SetField(ref _authorizationResult, value);
        }
        
        private string _password;
        public string Password
        {
            get => _password; 
            set => SetField(ref _password, value);
        }


        private string _email;
        public string Email
        {
            get => _email; 
            set => SetField(ref _email, value);
        }

        private bool _isVisibleView = true;
        public bool IsVisibleView
        {
            get => _isVisibleView;
            set => SetField(ref _isVisibleView, value);
        }





        //VIEW MODEL COMMANDS
        public LambdaCommand CommandCheck { get; set; }

        public LambdaCommand CommandClear { get; set; } 






        public CheckAuthorizedAccount_ViewModel() 
        {
            CommandCheck = new LambdaCommand(
                canExecute: _ => !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password),
            execute: _ =>
            {
                    _context.FindByIdPerson_return_PersonNotes(1); 
                    var accounts = _context.GetAuthorizedAccounts().Select(a => Mapper.MapFrom_AuthorizedAccountBLL_To_AuthorizedAccountAPL(a.UserID, a.FirstName, a.LastName, a.EmailAdress, a.Password, a.RoleId)).ToList();

                    IsVisibleView = accounts.Find(match => match.EmailAdress == Email)?.Password != Password ? true : false;
                    if (IsVisibleView)
                    {
                        Password = "";
                        AuthorizationResult = "* Авторизация не пройдена, проверьте логин или пароль";
                    }
                    else
                    {
                        //если находим пользователя
                        var acc = accounts.Find(match => match.EmailAdress == Email); 
                        if (acc != null)
                        {
                            //Заполняем глобальные данные об пользователе
                            Application.Current.Resources["UserFirstName"] = acc.FirstName;
                            Application.Current.Resources["UserLastName"] = acc.LastName;
                            Application.Current.Resources["UserId"] = acc.UserId;
                            Application.Current.Resources["RoleId"] = acc.RoleId;

                            //Заполняем Доступы к страницам
                            if (acc.RoleId == 2) Application.Current.Resources["Visibility_RadioButton_PersonBase"] = Visibility.Collapsed;
                        }
                    }
                }
                
            );

            CommandClear = new LambdaCommand(
                canExecute: _ => true,
                execute: _ =>
                {
                    Email = "";
                    Password = "";
                    AuthorizationResult = ""; 
                }
            );


        }
       

    }
}
