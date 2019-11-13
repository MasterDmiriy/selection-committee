using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class CoefficientRepository : ICoefficientRepository
    {
        private ApplicationContext _context;
        public CoefficientRepository(ApplicationContext db)
        {
            _context = db;
        }

        public IEnumerable<Сoefficient> GetAll()
        {
            return _context.Coefficients.ToList();
        }
    }
}