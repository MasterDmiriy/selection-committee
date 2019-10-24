using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class MarkSubject
    {
        [Key] 
        public int Id { get; set; }

        public Subject Subject { get; set; }

        [ForeignKey("Subject")] 
        public int SubjectId { get; set; }

        public Enrollee Enrollee { get; set; }
        [ForeignKey("Enrollee")]
        public string EnrolleeId { get; set; }

        public int Mark { set; get; }
    }
}