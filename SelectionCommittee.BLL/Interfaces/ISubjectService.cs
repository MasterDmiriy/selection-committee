using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDTO> GetCertificates();
        //EIE - extern independent evalution
        IEnumerable<SubjectDTO> GetSubjectsEIE();

        IEnumerable<SubjectDTO> GetSubjectsEIEByFacyltyId(int facultyId);
        IEnumerable<string> GetSubjectsNamesEIE(IEnumerable<FacultySubjectDTO> facultySubjects);

    }
}