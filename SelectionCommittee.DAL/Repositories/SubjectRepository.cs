using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private ApplicationContext _context;

        public SubjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetCertificates()
        {
            return _context.Subjects.Where(sub => sub.TypeSubjectId == 1 || sub.TypeSubjectId == 2).ToList();
        }

        public IEnumerable<Subject> GetSubjectsEIE()
        {
            return _context.Subjects.Where(sub => sub.TypeSubjectId == 2 || sub.TypeSubjectId == 3).ToList();
        }
    }
}