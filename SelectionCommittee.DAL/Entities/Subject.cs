using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeSubject TypeSubject { set; get; }

        [ForeignKey("TypeSubject")]
        public int TypeSubjectId { get; set; }
    }
}