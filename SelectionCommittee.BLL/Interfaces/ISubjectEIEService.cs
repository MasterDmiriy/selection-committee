using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ISubjectEIEService
    {
        IEnumerable<SubjectEIEDTO> GetAll();

    }
}