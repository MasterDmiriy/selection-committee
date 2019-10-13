using System;
using System.Data.Entity;
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

        public Enrollee Get(int id)
        {
            return _context.Enrollees.Find(id);
        }

        public void Update(Enrollee enrollee)
        {
            _context.Entry(enrollee).State = EntityState.Modified;
        }
    }
}
