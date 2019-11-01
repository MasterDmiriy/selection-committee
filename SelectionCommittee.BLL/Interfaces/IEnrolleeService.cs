using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;


namespace SelectionCommittee.BLL.Interfaces
{
    public interface IEnrolleeService : IDisposable
    {
        Task<OperationDetails> Create(EnrolleeDTO enrollee); 
        OperationDetails Update(EnrolleeDTO enrollee);
        //EnrolleeDTO Get(int id);

        void UpdateMarkSubjects(string id, IEnumerable<MarkSubjectDTO> markSubjectsDTO);

        IEnumerable<MarkSubjectDTO> GetMarkSubjectsEIE(string id);

        Task<ClaimsIdentity> Authenticate(EnrolleeDTO enrollee);
    }
}