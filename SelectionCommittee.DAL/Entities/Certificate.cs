

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }

        public SubjectCertificate Subject { set; get; }

        [ForeignKey("Subject")]
        public int SubjectId { set; get; }

        public int Mark { get; set; }
    }
}
