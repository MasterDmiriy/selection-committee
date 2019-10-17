using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class CertificateService : ICertificateService
    {
        private IUnitOfWork _database;

        public CertificateService(IUnitOfWork db)
        {
            _database = db;
        }
        public void Create(CertificateDTO certificate)
        {
            List<MarkSubjectCertificate> markSubjects = new List<MarkSubjectCertificate>();
            foreach (var markSubject in certificate.MarkSubjects)
            {
                markSubjects.Add(new MarkSubjectCertificate { SubjectId = markSubject.SubjectId, Mark = markSubject.Mark });
            }
            _database.CertificateRepository.Create(new Certificate() {MarkSubjects = markSubjects});
            _database.Save();
        }
    }
}