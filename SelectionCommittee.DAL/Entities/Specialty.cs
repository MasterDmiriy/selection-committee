using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
     public class Specialty
    {
        [Key]
        public int Number { get; set; }

        public string Name { get; set; }

        public int BudgetPlaces { get; set; }

        public int TotalPlaces { get; set; }

        public Region Region { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public Faculty Faculty { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }

    }
}
