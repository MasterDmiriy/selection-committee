
namespace SelectionCommittee.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IEnrolleeService CreateEnrolleService();
        IRegionService CreateRegionService();
        ICityService CreateCityService();
        IEducationalInstitutionService CreateEducationalInstitutionService();
        ISubjectService CreateSubjectService();

        IFacultyService CreateFacultyService();
        ISpecialtyService CreateSpecialtyService();
        IStatementService CreateStatementService();
        IMarkSubjectService CreateMarkSubjectService();
    }
}