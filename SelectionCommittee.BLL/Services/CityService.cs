using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class CityService : ICityService
    {
        private IUnitOfWork _database;

        public CityService(IUnitOfWork db)
        {
            _database = db;
        }
        public IEnumerable<CityDTO> GetCities()
        {
            var Cities = new List<CityDTO>();
            _database.CityRepository.GetAll().ToList().ForEach(city => Cities.Add(new CityDTO()
            {
                Id = city.Id,
                Name = city.Name
            }));
            return Cities;
        }
    }
}