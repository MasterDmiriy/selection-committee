using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private ApplicationContext _context;
        public SpecialtyRepository(ApplicationContext db)
        {
            _context = db;
        }
        public void Create(Specialty specialty)
        {
            _context.Specialties.Add(specialty);
        }

        public Specialty Get(int id)
        {
            return _context.Specialties.Find(id);
        }

        public IEnumerable<Specialty> GetAll()
        {
            return _context.Specialties.ToList();
        }

        public void Update(Specialty specialty)
        {
            _context.Entry(specialty).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var specialty = _context.Specialties.Find(id);
            if (specialty != null)
                _context.Specialties.Remove(specialty);
        }
    }
}