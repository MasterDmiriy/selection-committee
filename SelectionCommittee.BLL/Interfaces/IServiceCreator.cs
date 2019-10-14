
namespace SelectionCommittee.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IEnrolleService CreateEnrolleService();
        IRegionService CreateRegionService();
        ICityService CreateCityService();
        IEducationalInstitutionService CreateEducationalInstitutionService();
        ISubjectCertificateService CreateSubjectCertificateService();
        ISubjectEIEService CreateSubjectEIEService();
    }
}