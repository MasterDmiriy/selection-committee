using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IEducationalInstitutionRepository
    {
        IEnumerable<EducationalInstitution> GetAll();
    }
}