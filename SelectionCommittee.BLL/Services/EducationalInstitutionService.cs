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
        public IDictionary<string, IEnumerable<EducationalInstitutionDTO>> GetEducationalInstitutions()
        {
            var displayInstitutions = new Dictionary<string,IEnumerable<EducationalInstitutionDTO>>();
            var result = _database.EducationalInstitutionRepository.GetAll().OrderBy(ed=>ed.Region.Name).GroupBy(ed => ed.Region.Name);

            foreach (var groupInstitutions in result)
            {
               var educationalInstitutions = groupInstitutions.Select(educationalInstitution =>
                    new EducationalInstitutionDTO()
                    {
                        Id = educationalInstitution.Id, 
                        Name = educationalInstitution.Name
                    }).ToList();
                displayInstitutions.Add(groupInstitutions.Key,educationalInstitutions);
            }

            return displayInstitutions;
        }
    }
}