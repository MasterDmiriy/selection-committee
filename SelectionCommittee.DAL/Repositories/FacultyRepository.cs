using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private ApplicationContext _context;
        public FacultyRepository(ApplicationContext db)
        {
            _context = db;
        }

        public void Create(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
        }

        public void Delete(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty != null)
                _context.Faculties.Remove(faculty);
        }

        public Faculty Get(int id)
        {
            return _context.Faculties.Find(id);
        }

        public IEnumerable<Faculty> GetAll()
        {
            return _context.Faculties.Include(sub => sub.FirstSubjectEIE).Include(sub => sub.SecondSubjectEIE).
                Include(sub => sub.ThirdSubjectEIE).Include(sub => sub.FourthSubjectEIE).ToList();
        }

        public void Update(Faculty faculty)
        {
            _context.Entry(faculty).State = EntityState.Modified;
        }
    }
}