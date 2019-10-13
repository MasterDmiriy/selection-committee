using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private ApplicationContext _context;
        public StatementRepository(ApplicationContext db)
        {
            _context = db;
        }
        public void Create(Statement statement)
        {
            _context.Statements.Add(statement);
        }

        public IEnumerable<Statement> GetAll()
        {
            return _context.Statements.ToList();
        }
    }
}