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
                FacultyId = specialtyDTO.FacultyId
            };
            _database.SpecialtyRepository.Create(specialty);
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
                    Number = specialty.Number,
                    Name = specialty.Name,
                    BudgetPlaces = specialty.BudgetPlaces,
                    TotalPlaces = specialty.TotalPlaces,
                    Photo = specialty.Photo,
                    FacultyId = specialty.FacultyId
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
                    Number = specialty.Number,
                    Name = specialty.Name,
                    BudgetPlaces = specialty.BudgetPlaces,
                    TotalPlaces = specialty.TotalPlaces,
                    Photo = specialty.Photo,
                    FacultyId = specialty.FacultyId
                });
            }
            return specialtyDTO;
        }

        public SpecialtyDTO GetById(int id)
        {
            var specialty = _database.SpecialtyRepository.Get(id);
            return new SpecialtyDTO
            {
                Number = specialty.Number,
                Name = specialty.Name,
                BudgetPlaces = specialty.BudgetPlaces,
                TotalPlaces = specialty.TotalPlaces,
                Photo = specialty.Photo,
                FacultyId = specialty.FacultyId
            };
        }
    }
}
