using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        [Key]
        public string Email { get; set; }
        public uint AccessLevel { get; set; }

        public User(/*int userId,*/ string userName, string password, string email, uint accessLevel)
        {
            //UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
            AccessLevel = accessLevel;
        }

        public User(string email, string password)
        {
            UserName = "userName";
            Password = password;
            Email = email;
            AccessLevel = 2;
        }
        public User()
        {
            UserName = "userName";
            Password = "password";
            Email = "email";
            AccessLevel = 2;
        }
    }
}
