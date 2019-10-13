using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class SubjectEIERepository : ISubjectEIERepository
    {
        private ApplicationContext _context;

        public SubjectEIERepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SubjectEIE> GetAll()
        {
            return _context.SubjectEIEs.ToList();
        }
    }
}