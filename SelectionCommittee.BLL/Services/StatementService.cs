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
                SpecialtyId = statementDTO.SpecialtyId
            });
            _database.Save();
        }

        public IEnumerable<EnrolleeDTO> GetEnrolleeBySpecialtyId(int specialtyDTOId)
        {
            //var enrollees = _database.StatementRepository.GetAll().
            //    Where(state => state.SpecialtyId == specialtyDTOId).
            //    Select(state => state.Enrollee);
            //List<EnrolleeDTO> enrolleesDTO = new List<EnrolleeDTO>();
            //foreach(var enrollee in enrollees)
            //{
            //    enrolleesDTO.Add(new EnrolleeDTO
            //    {
            //        Id = enrollee.Id,
            //        Name = enrollee.Name,
            //        Surname = enrollee.Surname,
            //        Patronymic = enrollee.Patronymic,
            //        Photo = enrollee.Photo,
            //        Region = enrollee.Region.Name,
            //        City = enrollee.City.Name,
            //        EducationalInstitution = enrollee.EducationalInstitution.Name,
            //        CertificateDTO = 
            //    });
            //}
            throw new NotImplementedException();
            
        }
    }
}
