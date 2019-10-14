using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class RegionService : IRegionService
    {
        private IUnitOfWork _database;

        public RegionService(IUnitOfWork db)
        {
            _database = db;
        }

        public IEnumerable<RegionDTO> GetRegions()
        {
            var Regions = new List<RegionDTO>();
            _database.RegionRepository.GetAll().ToList().ForEach(region => Regions.Add(new RegionDTO()
            {
                Id = region.Id,
                Name = region.Name
            }));
            return Regions;
        }
    }
}