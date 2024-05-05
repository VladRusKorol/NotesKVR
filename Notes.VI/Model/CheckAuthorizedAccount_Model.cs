
using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class CheckAuthorizedAccount_Model: BaseINPC
    {
        private  int _userId;   
        public int UserId
        {
            get => this._userId;
            set => SetField(ref this._userId, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => this._firstName;
            set => SetField(ref this._firstName, value);
        }


        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetField(ref this._lastName, value);
        }

        private string _emailAdress;
        public string EmailAdress
        {
            get => this._emailAdress;
            set => SetField(ref this._emailAdress, value);
        }

        private string _password;
        public string Password
        {
            get => this._password;
            set => SetField(ref this._password, value);
        }

        private int _roleId;
        public int RoleId
        {
            get => this._roleId;
            set => SetField(ref this._roleId, value);
        }



        public CheckAuthorizedAccount_Model(int userId, string firstName, string lastName, string emailAdress, string password, int roleId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAdress;
            Password = password;
            RoleId = roleId;
        }
    }
}
