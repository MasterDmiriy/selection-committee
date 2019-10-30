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

        public IEnumerable<string> GetSubjectsNamesEIE(IEnumerable<FacultySubjectDTO> facultySubjects)
        {
            List<string> subjects = new List<string>();
            IEnumerable<SubjectDTO> subjectsEIE = GetSubjectsEIE();

            var facultySubjectsDTO = facultySubjects.OrderBy(sub => sub.PositionSubject).ToList();

            subjects.Add(subjectsEIE.First(subject => subject.Id == facultySubjectsDTO[0].SubjectId).Name);
            for (int i = 1; i < 5; i+=2)
            {
                if (facultySubjectsDTO[i+1].SubjectId!=0)
                {
                    subjects.Add(subjectsEIE.First(subject => subject.Id == facultySubjectsDTO[i].SubjectId).Name + " или " +
                                 subjectsEIE.First(subject => subject.Id == facultySubjectsDTO[i+1].SubjectId).Name);
                }
                else subjects.Add(subjectsEIE.First(subject => subject.Id == facultySubjectsDTO[i].SubjectId).Name);
            }

            return subjects;
        }
    }
}