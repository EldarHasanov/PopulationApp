using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ViewModel
{
    public class ReceiveRegions
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

                // Execute the query, and change the column values
                // you want to change.
                //serchedRegions.AddRange(query);

                regionList= query.ToList();
                /*foreach (Region ord in query)
                {
                    serchedRegions.AddRange(query);
                    // Insert any additional changes to column values.
                }*/

                //db.SaveChanges();
            }
        }
    }
}
