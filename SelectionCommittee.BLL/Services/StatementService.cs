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
    public class StatementService : IStatementService
    {
        private IUnitOfWork _database;

        public StatementService(IUnitOfWork db)
        {
            _database = db;
        }

        public void Create(StatementDTO statementDTO)
        {
            _database.StatementRepository.Create(new Statement
            {
                EnrolleeId = statementDTO.EnrolleeId,
                SpecialtyId = statementDTO.SpecialtyId,
                Priority = statementDTO.Priority
            });
            _database.Save();
        }

        public IEnumerable<EnrolleeDTO> GetEnrolleeBySpecialtyId(int specialtyDTOId)
        {
            var enrollees = _database.StatementRepository.GetAll().
                Where(state => state.SpecialtyId == specialtyDTOId).
                Select(state => state.Enrollee);
            List<EnrolleeDTO> enrolleesDTO = new List<EnrolleeDTO>();
            foreach (var enrollee in enrollees)
            {
                enrolleesDTO.Add(new EnrolleeDTO
                {
                    Id = enrollee.Id,
                    Name = enrollee.Name,
                    Surname = enrollee.Surname,
                    Patronymic = enrollee.Patronymic,
                    Photo = enrollee.Photo,
                    RegionId = enrollee.RegionId,
                    CityId = enrollee.CityId,
                    EducationalInstitutionId = enrollee.EducationalInstitutionId
                });
            }

            return enrolleesDTO;

        }

        public IEnumerable<int> GetFreePrioritiesByEnrollee(string enrolleeId)
        {
           return (new List<int>{1,2,3,4}).Except(_database.StatementRepository.GetAll().Where(statement => statement.EnrolleeId == enrolleeId)
                .Select(state => state.Priority));
        }
    }
}
