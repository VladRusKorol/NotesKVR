using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models.custome
{
    public class AuthorizedAccount
    {
        public AuthorizedAccount(int userId, string firstName, string lastName, string emailAdress, string password, int roleId) 
        {
            UserID = userId;
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAdress; 
            Password = password;
            RoleId = roleId;
        }

        public int UserID { get; set; }

        public string FirstName {get; set ;} = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string EmailAdress { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
