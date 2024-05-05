using Notes.APL.Common;
using Notes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notes.APL.ViewModel
{
    public class RegistrationWindow_ViewModel : BaseINPC
    {
        //VIEW MODEL CONTEXT
        private NotesContextBL _context = new NotesContextBL();

        private string _resultMSG = "";
        public string ResultMSG
        {
            get => this._resultMSG;
            set => SetField(ref this._resultMSG, value);
        }

        private string _success = "unknown";
        public string Success
        {
            get => this._success;
            set => SetField(ref this._success, value);
        }

        private string _inputFirstName;
        public string InputFirstName
        {
            get => this._inputFirstName;
            set => SetField(ref _inputFirstName, value);
        }

        private string _inputLastName;
        public string InputLastName
        {
            get => this._inputLastName;
            set => SetField(ref _inputLastName, value);
        }

        private string _inputEmail;
        public string InputEmail
        {
            get => this._inputEmail;
            set => SetField(ref _inputEmail, value);
        }

        private string _password;
        public string Password
        {
            get => this._password;
            set => SetField(ref this._password, value);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => this._phoneNumber; 
            set => SetField(ref this._phoneNumber, value);
        }


        public LambdaCommand CommandReg { get; set; }
        public LambdaCommand CommandClaear { get; set; }

        public RegistrationWindow_ViewModel()
        {
            CommandReg = new LambdaCommand(
                canExecute: _ =>    !String.IsNullOrEmpty(InputEmail) && 
                                    !String.IsNullOrEmpty(Password) && 
                                    !String.IsNullOrEmpty(InputFirstName) &&
                                    !String.IsNullOrEmpty(InputLastName) &&
                                    !String.IsNullOrEmpty(PhoneNumber),
                execute: _ =>
                {
                    int count_users = _context.FindByEmail_return_count_users(InputEmail);

                    if (count_users == 0)
                    {
                        _context.AddNewPersonStoreProcedure(InputFirstName, InputLastName, PhoneNumber, InputEmail, Password);

                        ResultMSG = "Регистрация прошла успешно";
                        if(Success == "good")
                        {
                            Success = "Good";
                        }
                        else
                        {
                            Success = "good";
                        }
                       
                    }
                    else if(count_users >= 1)
                    {
                        ResultMSG = "Извините, но пользователь c таким же пароль зарегистрирован в системе";
                        Success = "bad";
                        if (Success == "bad")
                        {
                            Success = "Bad";
                        }
                        else
                        {
                            Success = "bad";
                        }
                    }

                }

            );


            CommandClaear = new LambdaCommand(
                canExecute: _ => true,
                execute: _ =>
                {
                    InputEmail = "";
                    Password = "";
                    InputFirstName = "";
                    InputLastName = "";
                    PhoneNumber = "";

                }

            );






        }

    }
}
