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
        private ICityRepository _cityRepository;
        private IEducationalInstitutionRepository _educationalInstitutionRepository;
        private IFacultyRepository _facultyRepository;
        private IRegionRepository _regionRepository;
        private ISpecialtyRepository _specialtyRepository;
        private IStatementRepository _statementRepository;
        private ISubjectRepository _subjectRepository;
        private IMarkSubjectRepository _markSubjectRepository;
        private IFacultySubjectRepository _facultySubjectRepository;

        public UnitOfWork(string strConnection)
        {
            _db = new ApplicationContext(strConnection);
            _applicationUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _applicationRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _enrolleeManager = new EnrolleeManager(_db);
            _cityRepository = new CityRepository(_db);
            _educationalInstitutionRepository = new EducationalInstitutionRepository(_db);
            _facultyRepository = new FacultyRepository(_db);
            _regionRepository = new RegionRepository(_db);
            _specialtyRepository = new SpecialtyRepository(_db);
            _statementRepository = new StatementRepository(_db);
            _subjectRepository = new SubjectRepository(_db);
            _markSubjectRepository = new MarkSubjectRepository(_db);
            _facultySubjectRepository = new FacultySubjectRepository(_db);
        }

        

        public ApplicationUserManager UserManager => _applicationUserManager;

        public IEnrolleeManager EnrolleeManager => _enrolleeManager;

        public ApplicationRoleManager RoleManager => _applicationRoleManager;

        public ICityRepository CityRepository => _cityRepository;

        public IEducationalInstitutionRepository EducationalInstitutionRepository => _educationalInstitutionRepository;

        public IFacultyRepository FacultyRepository => _facultyRepository;

        public IRegionRepository RegionRepository => _regionRepository;

        public ISpecialtyRepository SpecialtyRepository => _specialtyRepository;

        public IStatementRepository StatementRepository => _statementRepository;

        public ISubjectRepository SubjectRepository => _subjectRepository;

        public IMarkSubjectRepository MarkSubjectRepository => _markSubjectRepository;

        public IFacultySubjectRepository FacultySubjectRepository => _facultySubjectRepository;

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}