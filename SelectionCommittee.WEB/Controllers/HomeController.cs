using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;

namespace SelectionCommittee.WEB.Controllers
{
    public class HomeController : Controller
    {
        IServiceCreator _creator = new ServiceCreator("DefaultConnection");
        public ActionResult Index()
        {
            var temp = _creator.CreateCityService().GetCities();
            return View();
        }
    }
}