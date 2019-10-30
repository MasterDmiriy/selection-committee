using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class EducationalInstitution
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public Region Region { get; set; }
        [ForeignKey("Region")]
        public int RegionId { set; get; }

        public bool IsCity { get; set; }
        public ICollection<Enrollee> Enrollees { set; get; }

        public EducationalInstitution()
        {
            Enrollees = new List<Enrollee>();
        }
    }
}
