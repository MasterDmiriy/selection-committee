using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IFacultySubjectRepository
    {
        void CreateRange(IEnumerable<FacultySubject> facultySubjects);

        IEnumerable<FacultySubject> GetAllByFacultyId(int facultyId);

        void UpdateRange(IEnumerable<FacultySubject> facultySubjects);
    }
}