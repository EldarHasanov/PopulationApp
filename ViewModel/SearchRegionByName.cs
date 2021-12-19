using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security;
using DAL;

namespace ViewModel
{
    public class SearchRegionByName
    {
        public List<Region> serchedRegions;

        public SearchRegionByName(string name)
        {
            using (DBContext db = new DBContext())
            {
                var query =
                    from ord in db.regions
                    where ord.Name == name
                    select ord;

                // Execute the query, and change the column values
                // you want to change.
                //serchedRegions.AddRange(query);

                serchedRegions = query.ToList();
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
