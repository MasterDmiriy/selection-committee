using System;
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
            return _context.Enrollees
                .Include(enrollee => enrollee.MarkSubjects.Select(mark=>mark.Subject))
                .Include(enrollee=> enrollee.City)
                .Include(enrollee=> enrollee.Region)
                .Include(enrollee=> enrollee.EducationalInstitution)
                .Include(enrollee=> enrollee.ApplicationUser)
                .FirstOrDefault(enrollee => enrollee.Id == id);
        }

        public void Update(Enrollee enrollee)
        {
            _context.Entry(enrollee).State = EntityState.Modified;
        }
    }
}
