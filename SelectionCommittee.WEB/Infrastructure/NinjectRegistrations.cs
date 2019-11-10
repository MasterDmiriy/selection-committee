using Ninject;
using Ninject.Modules;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;

namespace SelectionCommittee.WEB.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceCreator>().To<ServiceCreator>()
                .WithConstructorArgument("strConnection", "DefaultConnection");
        }
    }
}