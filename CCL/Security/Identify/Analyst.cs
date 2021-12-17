using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    public class Analyst : User
    {
        public Analyst(/*int userId, */string userName, string password, string email) : base(/*userId, */userName, password, email, 2)
        {
        }
        public Analyst() : base(/*1,*/ "TestName", "1111", "Analyst@gmail.com", 2)
        {
        }
    }
}
