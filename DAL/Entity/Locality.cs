using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entity
{
    public class Locality
    {
        [Key]
        public uint LocalityId { get; set; }

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
        public uint AverageEducation { get; set; }
        public double AverageEducationPer { get; set; }
        public uint RegionId { get; set; }

        public Locality(uint localityId, string name, uint men, uint woman, double averageAge,
            uint finishedSecondaryEducation, uint averageEducation, double averageEducationPer, uint regionId)
        {
            this.LocalityId = localityId;
            this.Name = name;
            this.Population = men + woman;
            this.Men = men;
            this.Woman = woman;
            this.AverageAge = averageAge;
            this.AverageEducation = averageEducation;
            this.AverageEducationPer = averageEducationPer;
            this.RegionId = regionId;
        }

        public Locality()
        {
            this.LocalityId = 1;
            this.Name = "TestName";
            this.Population = 100;
            this.Men = 51;
            this.Woman = 49;
            this.AverageAge = 40.3;
            this.AverageEducation = 2;
            this.AverageEducationPer = 54;
            this.RegionId = 1;
        }
    }
}
