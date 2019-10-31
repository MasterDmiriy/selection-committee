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
                EnrolleeDTO enrolleeDto = new EnrolleeDTO { UserName = model.Email, Password = model.Password };
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
                    if (User.IsInRole("admin"))
                        return RedirectToAction("Faculties", "Admin");
                    return RedirectToAction("Home", "SelectionCommittee");
                }
            }
            return View(model);
        }

        private RegisterModel necessaryModel = new RegisterModel();
        public ActionResult Register()
        {
            necessaryModel.Cities = _creator.CreateCityService().GetCities();
            necessaryModel.Regions = _creator.CreateRegionService().GetRegions();
            necessaryModel.EducationalInstitutions = _creator.CreateEducationalInstitutionService().GetEducationalInstitutions();
            return View(necessaryModel);
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
                    return View("Login", new LoginModel{Email = model.Email, Password = model.Password});
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }

            model.Cities = necessaryModel.Cities;
            model.Regions = necessaryModel.Regions;
            model.EducationalInstitutions = necessaryModel.EducationalInstitutions;
            return View(model);
        }
    }
}