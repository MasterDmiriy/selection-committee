using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class MarkSubjectCertificateService : IMarkSubjectCertificateService
    {
        private IUnitOfWork _database;

        public MarkSubjectCertificateService(IUnitOfWork db)
        {
            _database = db;
        }
        public void CreateRange(IEnumerable<MarkSubjectCertificateDTO> markSubjectsDTO)
        {
            List<MarkSubjectCertificate> markSubjects = new List<MarkSubjectCertificate>();
            foreach (var markSubject in markSubjectsDTO)
            {
                markSubjects.Add(new MarkSubjectCertificate{SubjectId = markSubject.SubjectId, Mark = markSubject.Mark});
            }
            _database.MarkSubjectCertificateRepository.CreateRange(markSubjects);
            _database.Save();
        }
    }
}