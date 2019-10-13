using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ISpecialtyRepository
    {
        void Create(Specialty specialty);

        Specialty Get(int id);

        IEnumerable<Specialty> GetAll();

        void Update(Specialty specialty);

        void Delete(int id);
    }
}