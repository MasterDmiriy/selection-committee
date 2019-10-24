using SelectionCommittee.DAL.Entities;
using System.Collections.Generic;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IMarkSubjectRepository
    {
        void CreateRange(IEnumerable<MarkSubject> markSubjects);
    }
}