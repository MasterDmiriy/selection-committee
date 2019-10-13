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
        public int EnrolleeId { get; set; }
        public Specialty Specialty { get; set; }

        [ForeignKey("Specialty")]
        public int SpecialtyId { get; set; }

        public MarkEIE FirstMarkEIE { get; set; }

        [ForeignKey("FirstMarkEIE")]
        public int FirstMark { get; set; }
        public MarkEIE SecondMarkEIE { get; set; }

        [ForeignKey("SecondMarkEIE")]
        public int SecondMark { get; set; }
        public MarkEIE ThirdMarkEIE { get; set; }

        [ForeignKey("ThirdMarkEIE")]
        public int ThirdMark { get; set; }

    }
}
