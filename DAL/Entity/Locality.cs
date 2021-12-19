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
        public uint FinishedProfileEducation { get; set; }
        public uint AverageEducation { get; set; }
        public double AverageEducationPer { get; set; }
        public uint Region { get; set; }

        public Locality(uint localityId, string name, uint men, uint woman, double averageAge,
            uint finishedSecondaryEducation, uint finishedProfileEducation, uint averageEducation, double averageEducationPer, uint region)
        {
            this.LocalityId = localityId;
            this.Name = name;
            this.Population = men + woman;
            this.Men = men;
            this.Woman = woman;
            this.AverageAge = averageAge;
            this.FinishedSecondaryEducation = finishedSecondaryEducation;
            this.FinishedProfileEducation = finishedProfileEducation;
            this.AverageEducation = averageEducation;
            this.AverageEducationPer = averageEducationPer;
            this.Region = region;
        }

        public Locality(string name, uint region, uint localityId)
        {
            this.LocalityId = localityId;
            this.Name = name;
            this.Population = 0;
            this.Men = 0;
            this.Woman = 0;
            this.AverageAge = 0;
            this.FinishedSecondaryEducation = 0;
            this.FinishedProfileEducation = 0;
            this.AverageEducation = 1;
            this.AverageEducationPer = 0;
            this.Region = region;
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
            this.Region = 1;
        }
    }
}
