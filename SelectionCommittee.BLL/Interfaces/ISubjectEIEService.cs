using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface ISubjectEIEService
    {
        IEnumerable<SubjectEIEDTO> GetAll();

    }
}