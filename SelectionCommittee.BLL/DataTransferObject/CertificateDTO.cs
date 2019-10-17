using System.Collections.Generic;

namespace SelectionCommittee.BLL.DataTransferObject
{
    public class CertificateDTO
    {
        public int Id { get; set; }
        public  IList<MarkSubjectCertificateDTO> MarkSubjects { set; get; }
    }
}