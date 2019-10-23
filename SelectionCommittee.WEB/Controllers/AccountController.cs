using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Threading.Tasks;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;
using SelectionCommittee.WEB.Models;

namespace SelectionCommittee.WEB.Controllers
{
    public class AccountController : Controller
    {
        IServiceCreator _creator = new ServiceCreator("DefaultConnection");
        private IEnrolleeService EnrolleeService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IEnrolleeService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                EnrolleeDTO enrolleeDto = new EnrolleeDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await EnrolleeService.Authenticate(enrolleeDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            DefaultModel model = new DefaultModel();
            model.Cities = _creator.CreateCityService().GetCities();
            model.Regions = _creator.CreateRegionService().GetRegions();
            model.EducationalInstitutions = _creator.CreateEducationalInstitutionService().GetEducationalInstitutions();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                EnrolleeDTO enrolleeDto = new EnrolleeDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    CityId = model.CityId,
                    RegionId = model.RegionId,
                    EducationalInstitutionId = model.EducationalInstitutionId,
                    Role = "enrollee",
                    UserName = model.Email
                };
                OperationDetails operationDetails = await EnrolleeService.Create(enrolleeDto);
                if (operationDetails.Succedeed)
                    return View();
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}