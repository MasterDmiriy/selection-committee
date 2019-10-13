using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IStatementRepository
    {
        void Create(Statement statement);

        IEnumerable<Statement> GetAll();
    }
}