using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Interfaces;
using SelectionCommittee.DAL.Repositories;

namespace SelectionCommittee.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        private IUnitOfWork _database;

        public ServiceCreator(string strConnection)
        {
            _database = new UnitOfWork(strConnection);
        }

        public ICityService CreateCityService()
        {
             return new CityService(_database);
        }

        public IEducationalInstitutionService CreateEducationalInstitutionService()
        {
            return new EducationalInstitutionService(_database);
        }

        public IEnrolleeService CreateEnrolleService()
        {
            return new EnrolleeService(_database);
        }

        public IRegionService CreateRegionService()
        {
            return new RegionService(_database);
        }


        public ISubjectService CreateSubjectService()
        {
            return new SubjectService(_database);
        }

        public IFacultyService CreateFacultyService()
        {
            return new FacultyService(_database);
        }

        public ISpecialtyService CreateSpecialtyService()
        {
           return new SpecialtyService(_database);
        }

        public IStatementService CreateStatementService()
        {
            return new StatementService(_database);
        }

        public IMarkSubjectService CreateMarkSubjectService()
        {
            return new MarkSubjectService(_database);
        }

    }
}