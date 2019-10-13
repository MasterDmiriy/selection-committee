using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IFacultyRepository
    {
        void Create(Faculty faculty);

        Faculty Get(int id);

        IEnumerable<Faculty> GetAll();

        void Update(Faculty faculty);

        void Delete(int id);
    }
}