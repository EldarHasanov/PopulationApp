using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ViewModel
{
    public class ReceiveRegions : ReciveInterface<Region>
    {
        public List<Region> regionList { get; set; }

        public ReceiveRegions(int page)
        {
            using (DBContext db = new DBContext())
            {
                var query =
                    from ord in db.regions
                    where ord.RegionId >= (page) * 100 + 1 && ord.RegionId <= (page + 1) * 100 + 1
                    select ord;
                regionList= query.ToList();
            }
        }

        public List<Region> Recive()
        {
            return regionList;
        }
    }
}
