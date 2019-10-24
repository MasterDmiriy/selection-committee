using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
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

        public void Create(FacultyDTO facultyDTO)
        {
            Faculty faculty = new Faculty
            {
                Name = facultyDTO.Name,
            };
            _database.FacultyRepository.Create(faculty);
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
                    Name = faculty.Name
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
                Name = faculty.Name
            };

        }

        public bool IsExist(int facultyDTOId)
        {
            return _database.FacultyRepository.Get(facultyDTOId) != null; 
        }
    }
}
