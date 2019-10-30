using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SelectionCommittee.BLL.Services
{
    public class FacultyService : IFacultyService
    {
        private IUnitOfWork _database;

        public FacultyService(IUnitOfWork db)
        {
            _database = db;
        }


        public void Delete(int facultyId)
        {
            _database.FacultyRepository.Delete(facultyId);
            _database.Save();
        }

        public void Update(FacultyDTO facultyDTO)
        {
            Faculty faculty = new Faculty
            {
                Id = facultyDTO.Id,
                Name = facultyDTO.Name,
                Description = facultyDTO.Description,
                Photo = facultyDTO.Photo
            };
            _database.FacultyRepository.Update(faculty);
            _database.Save();
            _database.FacultySubjectRepository.UpdateRange(ConvertSubject(facultyDTO.FacultySubjects, facultyDTO.Id));
            _database.Save();
        }

        public void Create(FacultyDTO facultyDTO)
        {
            Faculty faculty = new Faculty
            {
                Name = facultyDTO.Name,
                Photo = facultyDTO.Photo,
                Description = facultyDTO.Description
            };
            _database.FacultyRepository.Create(faculty);
            _database.Save();
            int facultyId = _database.FacultyRepository.GetAll().Select(f => f.Id).Max();
            _database.FacultySubjectRepository.CreateRange(ConvertSubject(facultyDTO.FacultySubjects, facultyId));
            _database.Save();
        }

       

        public IEnumerable<FacultyDTO> GetAll()
        {
            var faculties = _database.FacultyRepository.GetAll();
            List<FacultyDTO> facultiesDTO = new List<FacultyDTO>();
            foreach (var faculty in faculties)
            {
                facultiesDTO.Add(new FacultyDTO
                {
                    Id = faculty.Id,
                    Name = faculty.Name,
                    Photo = faculty.Photo,
                    Description = faculty.Description,
                    FacultySubjects = ConvertSubject(_database.FacultySubjectRepository.GetAllByFacultyId(faculty.Id))
                });
            }
            return facultiesDTO;
        }

        public FacultyDTO GetById(int id)
        {
            var faculty = _database.FacultyRepository.Get(id);
            return new FacultyDTO
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Photo = faculty.Photo,
                Description = faculty.Description,
                FacultySubjects = ConvertSubject(faculty.FacultySubjects)
            };

        }

        public bool IsExist(int facultyDTOId)
        {
            return _database.FacultyRepository.Get(facultyDTOId) != null; 
        }

        private IEnumerable<FacultySubject> ConvertSubject(IEnumerable<FacultySubjectDTO> facultySubjectsDTO, int facultyId)
        {
            List<FacultySubject> facultySubjects = new List<FacultySubject>();
            FacultySubject temp;
            foreach (var facultySubject in facultySubjectsDTO)
            {
                temp = new FacultySubject
                {
                    FacultyId = facultyId,
                    PositionSubject = facultySubject.PositionSubject,
                    SubjectId = facultySubject.SubjectId == 0 ? (int?)null : facultySubject.SubjectId
                };
                if (facultySubject.Id != 0)
                    temp.Id = facultySubject.Id;
                facultySubjects.Add(temp);

            }
            return facultySubjects;
        }

        private IList<FacultySubjectDTO> ConvertSubject(IEnumerable<FacultySubject> facultySubjects)
        {
            List<FacultySubjectDTO> facultySubjectsDTO = new List<FacultySubjectDTO>();
            foreach (var facultySubject in facultySubjects)
            {
                facultySubjectsDTO.Add(new FacultySubjectDTO
                {
                    Id = facultySubject.Id,
                    FacultyId = facultySubject.FacultyId,
                    SubjectId = facultySubject.SubjectId ?? 0,
                    PositionSubject = facultySubject.PositionSubject
                });
            }
            return facultySubjectsDTO;
        }
    }
}
