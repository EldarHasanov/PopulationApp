using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class ReceiveLocalitys
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

                // Execute the query, and change the column values
                // you want to change.
                //serchedLocalitys.AddRange(query);

                LocalityList = query.ToList();
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
