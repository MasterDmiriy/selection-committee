using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class CityRepository : ICityRepository
    {
        private ApplicationContext _context;
        public CityRepository(ApplicationContext db)
        {
            _context = db;
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities.ToList();
        }
    }
}