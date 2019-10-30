using System.Collections.Generic;
using System.Data.Entity;
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

        public void UpdateRange(IEnumerable<FacultySubject> facultySubjects)
        {
            foreach (var facultySubject in facultySubjects)
            {
                _context.Entry(facultySubject).State = EntityState.Modified;
            }
        }
    }
}