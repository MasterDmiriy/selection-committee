using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IEducationalInstitutionService
    {
       IDictionary<string,IEnumerable<EducationalInstitutionDTO>> GetEducationalInstitutions();
    }
}