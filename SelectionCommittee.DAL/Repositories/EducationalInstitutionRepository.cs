using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class EducationalInstitutionRepository : IEducationalInstitutionRepository
    {
        private ApplicationContext _context;
        public EducationalInstitutionRepository(ApplicationContext db)
        {
            _context = db;
        }
        public IEnumerable<EducationalInstitution> GetAll()
        {
            return _context.EducationalInstitutions.ToList();
        }
    }
}