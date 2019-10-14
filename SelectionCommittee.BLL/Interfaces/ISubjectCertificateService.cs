using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface ISubjectCertificateService
    {
        IEnumerable<SubjectCertificateDTO> GetSubjectCertificates();
    }
}