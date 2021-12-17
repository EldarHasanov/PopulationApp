using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    public class Interviewer : User
    {
        public Interviewer(/*int userId, */string userName, string password, string email) : base(/*userId, */userName, password, email, 3)
        {
        }
        public Interviewer() : base(/*1,*/ "TestName", "1111", "Interviewer@gmail.com", 3)
        {
        }
    }
}
