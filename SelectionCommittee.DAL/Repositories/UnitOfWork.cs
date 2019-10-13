using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Identity;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;

        private ApplicationRoleManager _applicationRoleManager;
        private ApplicationUserManager _applicationUserManager;
        private IEnrolleeManager _enrolleeManager;
        private ICertificateRepository _certificateRepository;
        private ICityRepository _cityRepository;
        private IEducationalInstitutionRepository _educationalInstitutionRepository;
        private IFacultyRepository _facultyRepository;
        private IRegionRepository _regionRepository;
        private ISpecialtyRepository _specialtyRepository;
        private IStatementRepository _statementRepository;
        private ISubjectCertificateRepository _subjectCertificateRepository;
        private ISubjectEIERepository _subjectEIERepository;

        public UnitOfWork(string strConnection)
        {
            _db = new ApplicationContext(strConnection);
            _applicationUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _applicationRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _enrolleeManager = new EnrolleeManager(_db);
            _certificateRepository = new CertificateRepository(_db);
            _cityRepository = new CityRepository(_db);
            _educationalInstitutionRepository = new EducationalInstitutionRepository(_db);
            _facultyRepository = new FacultyRepository(_db);
            _regionRepository = new RegionRepository(_db);
            _specialtyRepository = new SpecialtyRepository(_db);
            _statementRepository = new StatementRepository(_db);
            _subjectCertificateRepository = new SubjectCertificateRepository(_db);
            _subjectEIERepository = new SubjectEIERepository(_db);
        }

        public ApplicationUserManager UserManager => _applicationUserManager;

        public IEnrolleeManager EnrolleeManager => _enrolleeManager;

        public ApplicationRoleManager RoleManager => _applicationRoleManager;

        public ICertificateRepository CertificateRepository => _certificateRepository;

        public ICityRepository CityRepository => _cityRepository;

        public IEducationalInstitutionRepository EducationalInstitutionRepository => _educationalInstitutionRepository;

        public IFacultyRepository FacultyRepository => _facultyRepository;

        public IRegionRepository RegionRepository => _regionRepository;

        public ISpecialtyRepository SpecialtyRepository => _specialtyRepository;

        public IStatementRepository StatementRepository => _statementRepository;

        public ISubjectCertificateRepository SubjectCertificateRepository => _subjectCertificateRepository;

        public ISubjectEIERepository SubjectEIERepository => _subjectEIERepository;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}