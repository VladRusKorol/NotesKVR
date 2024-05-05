using Notes.BLL.Models.dic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models.custome
{
    public class UsersInfo
    {
        //------From Person--------------------------------------------------------
        public int UserId {  get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; }

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
