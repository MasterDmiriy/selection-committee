using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class MarkSubjectRepository : IMarkSubjectRepository
    {
        private ApplicationContext _context;
        public MarkSubjectRepository(ApplicationContext db)
        {
            _context = db;
        }

        public void CreateRange(IEnumerable<MarkSubject> markSubjects)
        {
            _context.MarkSubjects.AddRange(markSubjects);
        }
    }
}