using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    interface ReciveInterface<T> //стратегія
    {
        public List<T> Recive();
    }
}
