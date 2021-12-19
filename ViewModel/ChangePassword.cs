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
    public class ChangePassword
    {
        private Autentification Auten;
        private string NewPassword;

        public ChangePassword(Autentification autentification, String newPassword)
        {
            Auten = autentification;
            NewPassword = newPassword;
        }

        public Autentification Change(string oldPassword)
        {
            Hash encr = new Hash();
            int hash = encr.GetFNV1aHashCode(oldPassword);
            if (Auten.GetPassword() == hash.ToString())
            {
                using (DBContext db = new DBContext())
                {
                    hash = encr.GetFNV1aHashCode(NewPassword);
                    var query =
                        from ord in db.users
                        where ord.Email == Auten.GetEmail()
                        select ord;

                    // Execute the query, and change the column values
                    // you want to change.
                    foreach (User ord in query)
                    {
                        ord.Password = hash.ToString();
                        // Insert any additional changes to column values.
                    }

                    db.SaveChanges();

                    User tempUser = Auten.GetUser();
                    tempUser.Password = NewPassword;
                    return new Autentification(tempUser);
                }
            }
            else
            {
                throw new ChangePasswordException("Sommthing wrong with new password");
                return Auten;
            }
        }
    }
}
