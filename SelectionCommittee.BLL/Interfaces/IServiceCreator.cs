
namespace SelectionCommittee.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IEnrolleeService CreateEnrolleService();
        IRegionService CreateRegionService();
        ICityService CreateCityService();
        IEducationalInstitutionService CreateEducationalInstitutionService();
        ISubjectService CreateSubjectService();
    }
}