using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class ReciveDistrict
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

                // Execute the query, and change the column values
                // you want to change.
                //serchedLocalitys.AddRange(query);

                districtList = query.ToList();
                /*foreach (Locality ord in query)
                {
                    serchedLocalitys.AddRange(query);
                    // Insert any additional changes to column values.
                }*/

                //db.SaveChanges();
            }
        }
    }
}
