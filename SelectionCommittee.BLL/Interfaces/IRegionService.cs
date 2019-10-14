using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IRegionService
    {
        IEnumerable<RegionDTO> GetRegions();
    }
}