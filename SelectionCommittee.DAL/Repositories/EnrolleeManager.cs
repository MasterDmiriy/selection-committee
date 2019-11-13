using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class EnrolleeManager : IEnrolleeManager
    {
        private ApplicationContext _context;
        public EnrolleeManager(ApplicationContext db)
        {
            _context = db;
        }
        public void Create(Enrollee enrollee)
        {
            _context.Enrollees.Add(enrollee);
            _context.SaveChanges();
        }

        public Enrollee Get(string id)
        {
            var r = _context.Enrollees
                .Include(enrollee => enrollee.MarkSubjects.Select(mark => mark.Subject))
                .Include(enrollee => enrollee.Region)
                .Include(enrollee => enrollee.EducationalInstitution)
                .Include(enrollee => enrollee.ApplicationUser);
            return r
                .FirstOrDefault(enrollee => enrollee.Id == id);

        }

        public IEnumerable<Enrollee> GetAll()
        {
            return _context.Enrollees
                .Include(enrollee => enrollee.MarkSubjects.Select(mark => mark.Subject))
                .Include(enrollee => enrollee.Region)
                .Include(enrollee => enrollee.EducationalInstitution)
                .Include(enrollee => enrollee.ApplicationUser);
        }

        public void Update(Enrollee enrollee)
        {
            _context.Entry(enrollee).State = EntityState.Modified;
        }
    }
}
