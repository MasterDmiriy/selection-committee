using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IMarkSubjectCertificateService
    {
        void CreateRange(IEnumerable<MarkSubjectCertificateDTO> markSubjectsDTO);
    }
}