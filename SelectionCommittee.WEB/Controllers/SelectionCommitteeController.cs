using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;
using SelectionCommittee.WEB.Models;

namespace SelectionCommittee.WEB.Controllers
{
    public class SelectionCommitteeController : Controller
    {
        IServiceCreator _creator = new ServiceCreator("DefaultConnection");

        private IFacultyService _faculty;
        private ISpecialtyService _specialty;
        private ISubjectService _subject;

        public SelectionCommitteeController()
        {
            _faculty = _creator.CreateFacultyService();
            _specialty = _creator.CreateSpecialtyService();
            _subject = _creator.CreateSubjectService();
        }

        public ActionResult DropDownFaculties()
        {
            DisplayHome home = new DisplayHome
            {
                FacultiesDTO = _faculty.GetAll()
            };
            return PartialView(home);
        }

        public ActionResult Home()
        {
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("Faculties", "Admin");
            }
            return View();
        }

        
        public ActionResult Faculty(int id)
        {
            var faculty = _faculty.GetById(id);
            DisplayFullFaculty fullFaculty = new DisplayFullFaculty
            {
                Name = faculty.Name,
                Description = faculty.Description,
                Photo = faculty.Photo,
                Subjects = _subject.GetSubjectsNamesEIE(faculty.FacultySubjects),
                SpecialtiesDTO = _specialty.GetByFacultyId(id)
            };
            return View(fullFaculty);
        }

        public ActionResult Specialty(int id)
        {
            var specialty = _specialty.GetById(id);
            DisplaySpecialty displaySpecialty = new DisplaySpecialty
            {
                Id = specialty.Id,
                Name = specialty.Name,
                Description = specialty.Description,
                FacultyId = specialty.FacultyId,
                Number = string.Format("{0:d3}", specialty.Number),
                BudgetPlaces = specialty.BudgetPlaces,
                TotalPlaces = specialty.TotalPlaces
            };
            return View(displaySpecialty);
        }

        public ActionResult Statement(int specialId, int facultyId)
        {
            DisplayStatementSubjects statementSubjects = new DisplayStatementSubjects
            {
                SpecialtyId = specialId,
                SubjecstEIE = _subject.GetSubjectsEIEByFacyltyId(facultyId),
                SubjectsCertificate = _subject.GetCertificates()
            };
            return View();
        }


    }
}