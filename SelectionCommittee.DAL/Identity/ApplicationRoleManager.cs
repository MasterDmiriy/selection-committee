using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }
    }
}
