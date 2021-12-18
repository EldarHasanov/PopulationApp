using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security;
using DAL;
using PopulationApp;

namespace ViewModel
{
    public class Registration
    {
        private User newUser;

        public Registration(string email, string password, string userName, uint accessLevel)
        {
            if (userDoesntExist(email))
            {
                newUser = new User(userName, password, email, accessLevel);
            }
            else
            {
                throw new ExistExeption("This user already exist");
            }
        }

        private bool userDoesntExist(string email)
        {
            using (DBContext db = new DBContext())
            {
                if (db.users.FindAsync(email).Result == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void addUserToDataBase()
        {
            if (userDoesntExist(newUser.Email))
            {
                Hash encr = new Hash();
                int hash = encr.GetFNV1aHashCode(newUser.Password);
                newUser.Password = hash.ToString();

                using (DBContext db = new DBContext())
                {
                    db.AddRange(newUser);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new ExistExeption("This user already exist");
            }
        }
    }
}
