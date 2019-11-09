using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectionCommittee.BLL.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private IUnitOfWork _database;

        public SpecialtyService(IUnitOfWork db)
        {
            _database = db;
        }
        public void Create(SpecialtyDTO specialtyDTO)
        {
            Specialty specialty = new Specialty
            {
                Number = specialtyDTO.Number,
                Name = specialtyDTO.Name,
                BudgetPlaces = specialtyDTO.BudgetPlaces,
                TotalPlaces = specialtyDTO.TotalPlaces,
                Photo = specialtyDTO.Photo,
                FacultyId = specialtyDTO.FacultyId,
                Description = specialtyDTO.Description
            };
            _database.SpecialtyRepository.Create(specialty);
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.SpecialtyRepository.Delete(id);
            _database.Save();
        }

        public IEnumerable<SpecialtyDTO> GetAll()
        {
            var specialties = _database.SpecialtyRepository.GetAll();
            List<SpecialtyDTO> specialtyDTO = new List<SpecialtyDTO>();
            foreach(var specialty in specialties)
            {
                specialtyDTO.Add(new SpecialtyDTO
                {
                    Id = specialty.Id,
                    Number = specialty.Number,
                    Name = specialty.Name,
                    BudgetPlaces = specialty.BudgetPlaces,
                    TotalPlaces = specialty.TotalPlaces,
                    Photo = specialty.Photo,
                    FacultyId = specialty.FacultyId,
                    Description = specialty.Description
                });
            }
            return specialtyDTO;
        }

        public IEnumerable<SpecialtyDTO> GetByFacultyId(int facultyDTOId)
        {
            var specialties = _database.SpecialtyRepository.GetAll().
                Where(spec => spec.FacultyId == facultyDTOId);
            List<SpecialtyDTO> specialtyDTO = new List<SpecialtyDTO>();
            foreach (var specialty in specialties)
            {
                specialtyDTO.Add(new SpecialtyDTO
                {
                    Id = specialty.Id,
                    Number = specialty.Number,
                    Name = specialty.Name,
                    BudgetPlaces = specialty.BudgetPlaces,
                    TotalPlaces = specialty.TotalPlaces,
                    Photo = specialty.Photo,
                    FacultyId = specialty.FacultyId,
                    Description = specialty.Description
                });
            }
            return specialtyDTO;
        }

        public SpecialtyDTO GetById(int id)
        {
            var specialty = _database.SpecialtyRepository.Get(id);
            return new SpecialtyDTO
            {
                Id = specialty.Id,
                Number = specialty.Number,
                Name = specialty.Name,
                BudgetPlaces = specialty.BudgetPlaces,
                TotalPlaces = specialty.TotalPlaces,
                Photo = specialty.Photo,
                FacultyId = specialty.FacultyId,
                Description = specialty.Description
            };
        }


        public bool IsAvailable(string enrolleeId, int specialtyId)
        {
            return !_database.StatementRepository.GetAll().Any(statement =>
            statement.SpecialtyId == specialtyId && statement.EnrolleeId == enrolleeId);
        }

        public void Update(SpecialtyDTO specialtyDTO)
        {
            var specialty = new Specialty
            {
                Id = specialtyDTO.Id,
                Number = specialtyDTO.Number,
                Name = specialtyDTO.Name,
                BudgetPlaces = specialtyDTO.BudgetPlaces,
                TotalPlaces = specialtyDTO.TotalPlaces,
                Photo = specialtyDTO.Photo,
                FacultyId = specialtyDTO.FacultyId,
                Description = specialtyDTO.Description
            };
            _database.SpecialtyRepository.Update(specialty);
            _database.Save();
        }
    }
}
