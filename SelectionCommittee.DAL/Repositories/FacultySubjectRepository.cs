using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class FacultySubjectRepository : IFacultySubjectRepository
    {
        private ApplicationContext _context;
        public FacultySubjectRepository(ApplicationContext db)
        {
            _context = db;
        }
        public void CreateRange(IEnumerable<FacultySubject> facultySubjects)
        {
            _context.FacultySubjects.AddRange(facultySubjects);
        }

        public IEnumerable<FacultySubject> GetAllByFacultyId(int facultyId)
        {
            return _context.FacultySubjects.Where(faculty => faculty.FacultyId == facultyId).ToList();
        }
    }
}