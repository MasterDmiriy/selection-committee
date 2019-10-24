using SelectionCommittee.BLL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IMarkSubjectService
    {
        void CreateRange(IEnumerable<MarkSubjectDTO> markSubjectsDTO);
    }
}
