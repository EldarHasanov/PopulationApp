using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AutentificationExeption : Exception
    {
        public AutentificationExeption() : base() { }
        public AutentificationExeption(string message) : base(message) { }
    }
}
