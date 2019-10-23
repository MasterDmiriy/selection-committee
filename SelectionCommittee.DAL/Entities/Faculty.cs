using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public SubjectEIE FirstSubjectEIE { get; set; }

        [ForeignKey("FirstSubjectEIE")]
        public int? FirstSubjectId { get; set; }

        public SubjectEIE SecondSubjectEIE { get; set; }

        [ForeignKey("SecondSubjectEIE")]
        public int? SecondSubjectId { get; set; }

        public SubjectEIE ThirdSubjectEIE { get; set; }

        [ForeignKey("ThirdSubjectEIE")]
        public int? ThirdSubjectId { get; set; }

        public SubjectEIE FourthSubjectEIE { get; set; }

        [ForeignKey("FourthSubjectEIE")]
        public int? FourthSubjectId { get; set; }

        public IList<Specialty> Specialties { get; set; }

        public Faculty()
        {
            Specialties = new List<Specialty>();
        }
    }
}
