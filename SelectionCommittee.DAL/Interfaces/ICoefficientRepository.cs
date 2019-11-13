using SelectionCommittee.DAL.Entities;
using System.Collections.Generic;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ICoefficientRepository
    {
        IEnumerable<Сoefficient> GetAll();
    }
}