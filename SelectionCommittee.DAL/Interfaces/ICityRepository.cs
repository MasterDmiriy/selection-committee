using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
    }
}