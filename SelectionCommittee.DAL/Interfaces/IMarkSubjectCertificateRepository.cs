using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IMarkSubjectCertificateRepository
    {
        void CreateRange(IEnumerable<MarkSubjectCertificate> markSubjectCertificates);
        IEnumerable<MarkSubjectCertificate> GetAll();
    }
}