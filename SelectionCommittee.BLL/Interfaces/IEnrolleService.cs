using System.Security.Claims;
using System.Threading.Tasks;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;


namespace SelectionCommittee.BLL.Interfaces
{
    public interface IEnrolleService
    {
        Task<OperationDetails> Create(EnrolleeDTO enrollee); 
        OperationDetails Update(EnrolleeDTO enrollee);
        //EnrolleeDTO Get(int id);
        Task<ClaimsIdentity> Authenticate(EnrolleeDTO enrollee);
    }
}