using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
    }
}