using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ISubjectEIERepository 
    {
        IEnumerable<SubjectEIE> GetAll();

    }
}