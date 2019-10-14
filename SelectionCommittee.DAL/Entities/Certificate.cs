using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }

        public IList<MarkSubjectCertificate> MarkSubjects { set; get; }

        public Certificate()
        {
            MarkSubjects = new List<MarkSubjectCertificate>();
        }
    }
}
