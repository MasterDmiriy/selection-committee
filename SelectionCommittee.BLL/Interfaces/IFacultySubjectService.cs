using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IFacultySubjectService
    {
        void CreateRange(IEnumerable<FacultySubjectDTO> facultySubjectsDTO);

        IEnumerable<FacultySubjectDTO> GetAllByFacultyId(int facultyId);
    }
}