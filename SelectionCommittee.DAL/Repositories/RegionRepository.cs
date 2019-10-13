using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private ApplicationContext _context;
        public RegionRepository(ApplicationContext db)
        {
            _context = db;
        }
        public IEnumerable<Region> GetAll()
        {
            return _context.Regions.ToList();
        }
    }
}