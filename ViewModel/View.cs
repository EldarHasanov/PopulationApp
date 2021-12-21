using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace ViewModel
{
    public class View   //Адаптер
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Population { get; set; }
        public uint Men
        {
            get; set;
        }
        public uint Woman
        {
            get; set;
        }
        public double AverageAge { get; set; }
        public uint FinishedSecondaryEducation { get; set; }
        public uint FinishedProfileEducation { get; set; }
        public string AverageEducation { get; set; }
        public double AverageEducationPer { get; set; }

        public View(Region thisRegion)
        {
            Id = thisRegion.RegionId;
            Name = thisRegion.Name;
            Population = thisRegion.Population;
            Men = thisRegion.Men;
            Woman = thisRegion.Woman;
            AverageAge = thisRegion.AverageAge;
            FinishedSecondaryEducation = thisRegion.FinishedSecondaryEducation;
            FinishedProfileEducation = thisRegion.FinishedProfileEducation;
            if (thisRegion.AverageEducation == 1)
            {
                AverageEducation = "Технічна";
            }
            else
            {
                AverageEducation = "Гуманітарна";
            }

            AverageEducationPer = thisRegion.AverageEducationPer;
        }

        public View(Locality thisRegion)
        {

            Id = thisRegion.LocalityId;
            Name = thisRegion.Name;
            Population = thisRegion.Population;
            Men = thisRegion.Men;
            Woman = thisRegion.Woman;
            AverageAge = thisRegion.AverageAge;
            FinishedSecondaryEducation = thisRegion.FinishedSecondaryEducation;
            FinishedProfileEducation = thisRegion.FinishedProfileEducation;
            if (thisRegion.AverageEducation == 1)
            {
                AverageEducation = "Технічна";
            }
            else
            {
                AverageEducation = "Гуманітарна";
            }

            AverageEducationPer = thisRegion.AverageEducationPer;
        }

        public View(District thisRegion)
        {
            Id = thisRegion.DistrictId;
            Name = thisRegion.Name;
            Population = thisRegion.Population;
            Men = thisRegion.Men;
            Woman = thisRegion.Woman;
            AverageAge = thisRegion.AverageAge;
            FinishedSecondaryEducation = thisRegion.FinishedSecondaryEducation;
            FinishedProfileEducation = thisRegion.FinishedProfileEducation;
            if (thisRegion.AverageEducation == 1)
            {
                AverageEducation = "Технічна";
            }
            else
            {
                AverageEducation = "Гуманітарна";
            }

            AverageEducationPer = thisRegion.AverageEducationPer;
        }
    }
}
