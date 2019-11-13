using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IEnrolleeManager
    {
        void Create(Enrollee enrollee);
        Enrollee Get(string id);

        IEnumerable<Enrollee> GetAll();

        void Update(Enrollee enrollee);
    }
}