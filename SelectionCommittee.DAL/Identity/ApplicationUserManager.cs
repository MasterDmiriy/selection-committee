using Microsoft.AspNet.Identity;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}
