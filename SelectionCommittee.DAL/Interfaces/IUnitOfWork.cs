using System.Threading.Tasks;
using SelectionCommittee.DAL.Identity;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        IEnrolleeManager EnrolleeManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IFacultySubjectRepository FacultySubjectRepository { get; }

        ICityRepository CityRepository { get; }

        IEducationalInstitutionRepository EducationalInstitutionRepository { get; }

        IFacultyRepository FacultyRepository { get; }

        IRegionRepository RegionRepository { get; }

        ISpecialtyRepository SpecialtyRepository { get; }

        IStatementRepository StatementRepository { get; }

        ISubjectRepository SubjectRepository { get; }

        IMarkSubjectRepository MarkSubjectRepository { get; }

        ICoefficientRepository CoefficientRepository { get; }

        void Save();
        Task SaveAsync();
    }
}