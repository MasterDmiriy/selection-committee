using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IEducationalInstitutionService
    {
        IEnumerable<EducationalInstitutionDTO> GetEducationalInstitutions();
    }
}