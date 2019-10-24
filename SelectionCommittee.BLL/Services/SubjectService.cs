using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private IUnitOfWork _database;

        public SubjectService(IUnitOfWork db)
        {
            _database = db;
        }


        public IEnumerable<SubjectDTO> GetCertificates()
        {
            var Subjects = new List<SubjectDTO>();
            _database.SubjectRepository.GetCertificates().ToList().ForEach(subject => Subjects.Add(new SubjectDTO()
            {
                Id = subject.Id,
                Name = subject.Name,
                TypeSubjectId = subject.TypeSubjectId
            }));
            return Subjects;
        }

        public IEnumerable<SubjectDTO> GetSubjectsEIE()
        {
            var Subjects = new List<SubjectDTO>();
            _database.SubjectRepository.GetSubjectsEIE().ToList().ForEach(subject => Subjects.Add(new SubjectDTO()
            {
                Id = subject.Id,
                Name = subject.Name,
                TypeSubjectId = subject.TypeSubjectId
            }));
            return Subjects;
        }
    }
}