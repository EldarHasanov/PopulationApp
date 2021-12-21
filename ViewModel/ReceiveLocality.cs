using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class ReceiveLocalitys : ReciveInterface<Locality>
    {
        public List<Locality> LocalityList { get; set; }

        public ReceiveLocalitys(uint RegId)
        {
            using (DBContext db = new DBContext())
            {
                var query =
                    from ord in db.localitys
                    where ord.Region == RegId
                    select ord;

                LocalityList = query.ToList();
            }
        }

        public List<Locality> Recive()
        {
            return LocalityList;
        }
    }
}
