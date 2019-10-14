using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        private IUnitOfWork _database;

        public ServiceCreator(IUnitOfWork db)
        {
            _database = db;
        }

        public ICityService CreateCityService()
        {
             return new CityService(_database);
        }

        public IEducationalInstitutionService CreateEducationalInstitutionService()
        {
            return new EducationalInstitutionService(_database);
        }

        public IEnrolleService CreateEnrolleService()
        {
            return new EnrolleeService(_database);
        }

        public IRegionService CreateRegionService()
        {
            return new RegionService(_database);
        }

        public ISubjectCertificateService CreateSubjectCertificateService()
        {
            return new SubjectCertificateService(_database);
        }

        public ISubjectEIEService CreateSubjectEIEService()
        {
            return new SubjectEIEService(_database);
        }
    }
}