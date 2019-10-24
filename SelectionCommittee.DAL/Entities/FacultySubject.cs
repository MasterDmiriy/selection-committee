using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class FacultySubject
    {
        [Key]
        public int Id { get; set; }

        public Faculty Faculty { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }

        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public int PositionSubject { get; set; }
    }
}