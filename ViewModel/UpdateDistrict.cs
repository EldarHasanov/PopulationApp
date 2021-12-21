using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class UpdateDistrict   //Фасад
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

            if (finishProf)
            {
                var selEdDist = ((ThisDistrict.AverageEducationPer / 100) * (ThisDistrict.FinishedProfileEducation));
                var selEdLoc = ((ThisLocality.AverageEducationPer / 100) * (ThisLocality.FinishedProfileEducation));
                var selEdReg = ((ThisRegion.AverageEducationPer / 100) * (ThisRegion.FinishedProfileEducation));
                
                if (EdType == ThisDistrict.AverageEducation)
                {
                    selEdDist++;
                }

                if (EdType == ThisLocality.AverageEducation)
                {
                    selEdLoc++;
                }

                if (EdType == ThisRegion.AverageEducation)
                {
                    selEdReg++;
                }


                ThisDistrict.FinishedProfileEducation++;
                ThisLocality.FinishedProfileEducation++;
                ThisRegion.FinishedProfileEducation++;
                

                ThisDistrict.AverageEducationPer =  (selEdDist / (double)ThisDistrict.FinishedProfileEducation) * 100;
                if (ThisDistrict.AverageEducationPer <= 50)
                {
                    if (ThisDistrict.AverageEducation == 1)
                    {
                        ThisDistrict.AverageEducation = 2;
                        ThisDistrict.AverageEducationPer = 100 - ThisDistrict.AverageEducationPer;
                    }
                    else
                    {
                        ThisDistrict.AverageEducation = 1;
                        ThisDistrict.AverageEducationPer = 100 - ThisDistrict.AverageEducationPer;
                    }
                }
                ThisLocality.AverageEducationPer = (selEdLoc / (double)ThisLocality.FinishedProfileEducation) * 100;
                if (ThisLocality.AverageEducationPer <= 50)
                {
                    if (ThisLocality.AverageEducation == 1)
                    {
                        ThisLocality.AverageEducation = 2;
                        ThisLocality.AverageEducationPer = 100 - ThisLocality.AverageEducationPer;
                    }
                    else
                    {
                        ThisLocality.AverageEducation = 1;
                        ThisLocality.AverageEducationPer = 100 - ThisLocality.AverageEducationPer;
                    }
                }
                ThisRegion.AverageEducationPer = (selEdReg / (double)ThisRegion.FinishedProfileEducation) *100;
                if (ThisRegion.AverageEducationPer <= 50)
                {
                    if (ThisRegion.AverageEducation == 1)
                    {
                        ThisRegion.AverageEducation = 2;
                        ThisRegion.AverageEducationPer = 100 - ThisRegion.AverageEducationPer;
                    }
                    else
                    {
                        ThisRegion.AverageEducation = 1;
                        ThisRegion.AverageEducationPer = 100 - ThisRegion.AverageEducationPer;
                    }
                }
            }

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
                db.SaveChanges();
            }
        }
    }
}
