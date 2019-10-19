﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class City
    {
        [Key]
        public  int Id { set; get; }
        public string Name { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public IList<EducationalInstitution> EducationalInstitutions { set; get; }

        public City()
        {
            EducationalInstitutions = new List<EducationalInstitution>();
        }
    }
}
