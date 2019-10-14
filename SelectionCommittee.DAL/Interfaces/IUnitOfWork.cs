using System.Threading.Tasks;
using SelectionCommittee.DAL.Identity;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        IEnrolleeManager EnrolleeManager { get; }
        ApplicationRoleManager RoleManager { get; }

        ICertificateRepository CertificateRepository { get; }

        ICityRepository CityRepository { get; }

        IEducationalInstitutionRepository EducationalInstitutionRepository { get; }

        IFacultyRepository FacultyRepository { get; }

        IRegionRepository RegionRepository { get; }

        ISpecialtyRepository SpecialtyRepository { get; }

        IStatementRepository StatementRepository { get; }

        ISubjectCertificateRepository SubjectCertificateRepository { get; }

        ISubjectEIERepository SubjectEIERepository { get; }

        IMarkSubjectCertificateRepository MarkSubjectCertificateRepository { get; }

        Task SaveAsync();
    }
}