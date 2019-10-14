using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class SubjectCertificateService : ISubjectCertificateService
    {
        private IUnitOfWork _database;

        public SubjectCertificateService(IUnitOfWork db)
        {
            _database = db;
        }
        public IEnumerable<SubjectCertificateDTO> GetSubjectCertificates()
        {
            var Subjects = new List<SubjectCertificateDTO>();
            _database.SubjectCertificateRepository.GetAll().ToList().ForEach(subject => Subjects.Add(new SubjectCertificateDTO()
            {
                Id = subject.Id,
                Name = subject.Name
            }));
            return Subjects;
        }
    }
}