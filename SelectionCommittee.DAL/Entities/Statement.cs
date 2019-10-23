using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Statement
    {
        [Key] 
        public int Id { get; set; }

        public Enrollee Enrollee { get; set; }

        [ForeignKey("Enrollee")]
        public string EnrolleeId { get; set; }
        public Specialty Specialty { get; set; }

        [ForeignKey("Specialty")]
        public int SpecialtyId { get; set; }
    }
}
