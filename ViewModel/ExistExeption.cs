using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ExistExeption : Exception
    {
        public ExistExeption() : base() { }
        public ExistExeption(string message) : base(message) { }
    }

    public class AutentificationExeption : Exception
    {
        public AutentificationExeption() : base() { }
        public AutentificationExeption(string message) : base(message) { }
    }

    public class ChangePasswordException : Exception
    {
        public ChangePasswordException() : base() { }
        public ChangePasswordException(string message) : base(message) { }
    }
}
