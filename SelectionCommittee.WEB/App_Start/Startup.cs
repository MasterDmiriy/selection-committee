using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;

[assembly: OwinStartup(typeof(SelectionCommittee.WEB.Startup))]

namespace SelectionCommittee.WEB
{
    
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator("DefaultConnection");

        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext(serviceCreator.CreateEnrolleService);
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
        
    }
}