using SelectionCommittee.BLL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IStatementService
    {
        void Create(StatementDTO statementDTO);
        IEnumerable<EnrolleeDTO> GetEnrolleeBySpecialtyId(int specialtyDTOId);

        IEnumerable<int> GetFreePrioritiesByEnrollee(string enrolleeId);


    }
}
