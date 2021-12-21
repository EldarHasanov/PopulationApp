using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class ReciveDistrict : ReciveInterface<District>
    {
        public List<District> districtList { get; set; }

        public ReciveDistrict(uint LocId)
        {
            using (DBContext db = new DBContext())
            {
                var query =
                    from ord in db.districts
                    where ord.Locality == LocId
                    select ord;

                districtList = query.ToList();
            }
        }

        public List<District> Recive()
        {
            return districtList;
        }
    }
}
