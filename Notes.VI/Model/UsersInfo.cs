using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class UsersInfo : BaseINPC
    {

        private int _userId;
        public int UserId
        {
            get => this._userId;
            set => SetField(ref _userId, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => this._firstName;
            set => SetField(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => this._lastName;
            set => SetField(ref _lastName, value);
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get => this._emailAddress;
            set => SetField(ref _emailAddress, value);
        }

        private string _password;
        public string Password
        {
            get => this._password;
            set => SetField(ref _password, value);
        }


        //------From dic.Role--------------------------------------------------------
        private string _role;
        public string Role
        {
            get => this._role;
            set => SetField(ref _role, value);
        }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get => this._phoneNumber;
            set => SetField(ref _phoneNumber, value);
            //set 
                //{
                    //if (SetField(ref _phoneNumber, value))
                    //{
                    //    idUser 
                    //}
           // }
        }




        public UsersInfo(int userId, string firstName, string lastName, string email, string password, string role, string phoneNumber)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = email;
            this.Password = password;
            this.Role = role;
            this.PhoneNumber = phoneNumber;
        }
    }
}
