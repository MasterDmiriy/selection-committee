using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class FacultySubjectService : IFacultySubjectService
    {
        private IUnitOfWork _database;

        public FacultySubjectService(IUnitOfWork db)
        {
            _database = db;
        }


        public void CreateRange(IEnumerable<FacultySubjectDTO> facultySubjectsDTO)
        {
            var facultySubjects = new List<FacultySubject>();
            foreach (var facultySubject in facultySubjectsDTO)
            {
                facultySubjects.Add(new FacultySubject
                {
                    FacultyId = facultySubject.FacultyId,
                    SubjectId = facultySubject.SubjectId,
                    PositionSubject = facultySubject.PositionSubject
                });
            }
            _database.FacultySubjectRepository.CreateRange(facultySubjects);
        }


        public IEnumerable<FacultySubjectDTO> GetAllByFacultyId(int facultyId)
        {
            var facultySubjects = _database.FacultySubjectRepository.GetAllByFacultyId(facultyId);
            var facultySubjectsDTO = new List<FacultySubjectDTO>();
            foreach (var facultySubject in facultySubjects)
            {
                facultySubjectsDTO.Add(new FacultySubjectDTO
                {
                    FacultyId = facultySubject.FacultyId,
                    SubjectId = facultySubject.SubjectId,
                    PositionSubject = facultySubject.PositionSubject
                });
            }

            return facultySubjectsDTO;
        }
    }
}