using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class SubjectEIEService : ISubjectEIEService
    {
        private IUnitOfWork _database;

        public SubjectEIEService(IUnitOfWork db)
        {
            _database = db;
        }

        public IEnumerable<SubjectEIEDTO> GetAll()
        {
            var Subjects = new List<SubjectEIEDTO>();
            _database.SubjectEIERepository.GetAll().ToList().ForEach(subject => Subjects.Add(new SubjectEIEDTO()
            {
                Id = subject.Id,
                Name = subject.Name
            }));
            return Subjects;
        }
    }
}