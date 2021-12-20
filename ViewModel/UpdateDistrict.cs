using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class UpdateDistrict
    {
        private District ThisDistrict;
        private Region ThisRegion;
        private Locality ThisLocality;

        public UpdateDistrict(Region thisRegion, Locality thisLocality, District thisDistrict)
        {
            if (thisDistrict.Locality == thisLocality.LocalityId && thisLocality.Region == thisRegion.RegionId)
            {
                ThisLocality = thisLocality;
                ThisDistrict = thisDistrict;
                ThisRegion = thisRegion;
            }
        }

        public void DoUpdate(bool man, double age, bool finishSecond, bool finishProf, int EdType = 1)
        {
            double temp = (((ThisDistrict.AverageAge * ThisDistrict.Population) + age) / (ThisDistrict.Population + 1));
            ThisDistrict.AverageAge = temp;
            temp = (((ThisLocality.AverageAge * ThisLocality.Population) + age) / (ThisLocality.Population + 1));
            ThisLocality.AverageAge = temp;
            temp = (((ThisRegion.AverageAge * ThisRegion.Population) + age) / (ThisRegion.Population + 1));
            ThisRegion.AverageAge = temp;

            if (finishSecond)
            {
                ThisDistrict.FinishedSecondaryEducation++;
                ThisLocality.FinishedSecondaryEducation++;
                ThisRegion.FinishedSecondaryEducation++;
            }

            /*if (finishProf)
            {
                if (ThisDistrict)
                {
                    
                }
                temp = (ThisDistrict.FinishedProfileEducation * (ThisDistrict.AverageEducationPer / 100));
            }*/

            ThisDistrict.Population++;
            ThisLocality.Population++;
            ThisRegion.Population++;
            if (man)
            {
                ThisDistrict.Men++;
                ThisLocality.Men++;
                ThisRegion.Men++;

            }
            else
            {
                ThisDistrict.Woman++;
                ThisLocality.Woman++;
                ThisRegion.Woman++;
            }



            using (DBContext db = new DBContext())
            {
                db.districts.Update(ThisDistrict);
                db.localitys.Update(ThisLocality);
                db.regions.Update(ThisRegion);
            }
        }
    }
}
