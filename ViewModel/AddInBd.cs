using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security;
using DAL;
using DAL.Entity;
using PopulationApp;

namespace ViewModel
{
    public class AddRegInBd
    {
        public Region Field;

        public AddRegInBd(String name)
        {
            
            using (DBContext db = new DBContext())
            {
                
                Field = new Region(name, (uint)(db.regions.Count() + 1));
                
                db.regions.Add(Field);

                db.SaveChanges();
                //AAA.Text = thisUser.ToString();
            }
        }
    }

    public class AddLocInBd
    {
        public Locality Field;

        public AddLocInBd(String name, uint RegionId)
        {

            using (DBContext db = new DBContext())
            {

                Field = new Locality(name, RegionId, (uint)(db.localitys.Count() + 1));

                db.localitys.Add(Field);

                db.SaveChanges();
                //AAA.Text = thisUser.ToString();
            }
        }
    }

    public class AddDisInBd
    {
        public District Field;

        public AddDisInBd(String name, uint LocalityId)
        {

            using (DBContext db = new DBContext())
            {

                Field = new District(name,  (uint)(db.districts.Count() + 1), LocalityId);

                db.districts.Add(Field);

                db.SaveChanges();
                //AAA.Text = thisUser.ToString();
            }
        }
    }
}
