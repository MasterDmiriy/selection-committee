using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class MarkEIERepository : IMarkEIERepository
    {
        private ApplicationContext _context;
        public MarkEIERepository(ApplicationContext db)
        {
            _context = db;
        }

        public void CreateRange(IEnumerable<MarkEIE> marksEIE)
        {
            _context.MarkEIEs.AddRange(marksEIE);
        }
    }
}