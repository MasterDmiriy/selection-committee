using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class EducationalInstitutionService : IEducationalInstitutionService
    {
        private IUnitOfWork _database;

        public EducationalInstitutionService(IUnitOfWork db)
        {
            _database = db;
        }
        public IEnumerable<EducationalInstitutionDTO> GetEducationalInstitutions()
        {
            var EducationalInstitutions = new List<EducationalInstitutionDTO>();
            _database.EducationalInstitutionRepository.GetAll().ToList().ForEach(institution => EducationalInstitutions.Add(new EducationalInstitutionDTO()
            {
                Id = institution.Id,
                Name = institution.Name
            }));
            return EducationalInstitutions;
        }
    }
}