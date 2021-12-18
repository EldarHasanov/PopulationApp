using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
//using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using CCL.Security;
using DAL;
using PopulationApp;

namespace ViewModel
{
    public class Autentification
    {
        private User AutentificatedUser;
        private uint accessLevel;
        private string Name;

        public Autentification (User checkingUser)
        {
            using (DBContext db = new DBContext())
            {
                ValueTask<User> ThisUser = db.users.FindAsync(checkingUser.Email);
                if (ThisUser.Result != null)
                {
                    User thisUser = ThisUser.Result;
                    Hash encr = new Hash();
                    int hash = encr.GetFNV1aHashCode(checkingUser.Password);
                    if (thisUser.Password == hash.ToString())
                    {
                        AutentificatedUser = thisUser;
                        accessLevel = thisUser.AccessLevel;
                        Name = thisUser.UserName;
                    }
                    else
                    {
                        throw new AutentificationExeption("Wrong password or login");
                    }
                }
                //AAA.Text = thisUser.ToString();
            }
        }
        public uint GetAccessLevel()
        {
            return accessLevel;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetPassword()
        {
            return AutentificatedUser.Password;
        }
        public string GetEmail()
        {
            return AutentificatedUser.Email;
        }
    }
}
