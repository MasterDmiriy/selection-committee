using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;
using SelectionCommittee.WEB.Models;

namespace SelectionCommittee.WEB.Controllers
{

    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IServiceCreator _creator = new ServiceCreator("DefaultConnection");

        private IFacultyService _faculty;
        private ISpecialtyService _specialty;

        private ISubjectService _subject;

        public AdminController()
        {
            _faculty = _creator.CreateFacultyService();
            _specialty = _creator.CreateSpecialtyService();
            _subject = _creator.CreateSubjectService();
        }

        public ActionResult Faculties()
        {
            List<DisplayFaculty> faculties = new List<DisplayFaculty>();
            foreach (var faculty in _faculty.GetAll())
            {
                faculties.Add(new DisplayFaculty
                {
                    Id = faculty.Id,
                    Name = faculty.Name,
                    Subjects = _subject.GetSubjectsNamesEIE(faculty.FacultySubjects),
                    CountSpeciality = _specialty.GetByFacultyId(faculty.Id).Count()
                });
            }

            return View(faculties);
        }



        [HttpGet]
        public ActionResult Specialties(int facultyId)
        {
            ViewBag.FacultyId = facultyId;
            return View(_specialty.GetByFacultyId(facultyId));
        }

        public ActionResult CreateFaculty()
        {
            CreateFaculty facultyCreate = new CreateFaculty();
            facultyCreate.Subjects = _subject.GetSubjectsEIE().ToList();
            return View(facultyCreate);
        }

        [HttpPost]
        public ActionResult CreateFaculty(CreateFacultyPost createFacultyPost, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                FacultyDTO faculty = new FacultyDTO
                {
                    Name = createFacultyPost.Name,
                    Description = createFacultyPost.Description,
                    FacultySubjects = createFacultyPost.FacultySubjects
                };
                if (image != null)
                {
                    string filePath = "/Content/Image/Faculties/" + faculty.Name + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath(filePath));
                    faculty.Photo = filePath;
                }

                _faculty.Create(faculty);
            }

            return RedirectToAction("Faculties");
        }

        public ActionResult DeleteFaculty(int facultyId)
        {
            if (facultyId != 0)
            {
                string temp = _faculty.GetById(facultyId).Photo;
                if(temp!=null)
                    System.IO.File.Delete(Server.MapPath(temp));
                _faculty.Delete(facultyId);
            }

            return RedirectToAction("Faculties");
        }

        [HttpGet]
        public ActionResult EditFaculty(int facultyId)
        {
            var faculty = _faculty.GetById(facultyId);
            var editFaculty = new EditFaculty
            {
                Id = faculty.Id,
                Name = faculty.Name,
                FacultySubjects = faculty.FacultySubjects.ToList(),
                Description = faculty.Description,
                Photo = faculty.Photo,
                Subjects = _subject.GetSubjectsEIE().ToList()
            };
            return View(editFaculty);
        }

        [HttpPost]
        public ActionResult EditFaculty(EditFaculty editFaculty, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                FacultyDTO faculty= new FacultyDTO
                {
                    Id = editFaculty.Id,
                    Name = editFaculty.Name,
                    Description = editFaculty.Description,
                    FacultySubjects = editFaculty.FacultySubjects
                };
                if (image != null)
                {
                    string filePath = "/Content/Image/Faculties/" + faculty.Name + Path.GetExtension(image.FileName);
                    if (editFaculty.Photo!=null)
                        System.IO.File.Delete(Server.MapPath(filePath));
                    image.SaveAs(Server.MapPath(filePath));
                    faculty.Photo = filePath;
                    
                }
                else faculty.Photo = editFaculty.Photo;

                _faculty.Update(faculty);
            }

            return RedirectToAction("Faculties");
        }

        [HttpGet]
        public ActionResult CreateSpecialty(int facultyId)
        {
            return View(new CreateSpecialty {FacultyId = facultyId});
        }

        [HttpPost]
        public ActionResult CreateSpecialty(CreateSpecialty createSpecialty, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                SpecialtyDTO specialty = new SpecialtyDTO
                {
                    Number = createSpecialty.Number,
                    Name = createSpecialty.Name,
                    BudgetPlaces = createSpecialty.BudgetPlaces,
                    TotalPlaces = createSpecialty.TotalPlaces,
                    Description = createSpecialty.Description,
                    FacultyId = createSpecialty.FacultyId
                };
                if (image != null)
                {
                    string filePath = "/Content/Image/Specialties/" + specialty.Name + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath(filePath));
                    specialty.Photo = filePath;
                }

                _specialty.Create(specialty);
            }

            return RedirectToAction("CreateSpecialty", new {facultyId = createSpecialty.FacultyId});
        }

        [HttpGet]
        public ActionResult EditSpecialty(int id)
        {
            var specialty = _specialty.GetById(id);
            var editSpecialty = new EditSpecialty
            {
                Id = specialty.Id,
                Number = specialty.Number,
                Name = specialty.Name,
                Description = specialty.Description,
                Photo = specialty.Photo,
                FacultyId = specialty.FacultyId,
                BudgetPlaces = specialty.BudgetPlaces,
                TotalPlaces = specialty.TotalPlaces
            };
            return View(editSpecialty);
        }

        [HttpPost]
        public ActionResult EditSpecialty(EditSpecialty editSpecialty, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                SpecialtyDTO specialty = new SpecialtyDTO
                {
                    Id = editSpecialty.Id,
                    Number = editSpecialty.Number,
                    Name = editSpecialty.Name,
                    Description = editSpecialty.Description,
                    FacultyId = editSpecialty.FacultyId,
                    BudgetPlaces = editSpecialty.BudgetPlaces,
                    TotalPlaces = editSpecialty.TotalPlaces
                };
                if (image != null)
                {
                    string filePath = "/Content/Image/Specialties/" + specialty.Name + Path.GetExtension(image.FileName);
                    if (editSpecialty.Photo!=null)
                        System.IO.File.Delete(Server.MapPath(filePath));
                    image.SaveAs(Server.MapPath(filePath));
                    specialty.Photo = filePath;
                    

                }
                else specialty.Photo = editSpecialty.Photo;

                _specialty.Update(specialty);
            }
            return RedirectToAction("Specialties",new {facultyId = editSpecialty.FacultyId});
        }

        public ActionResult DeleteSpecialty(int id, int facultyId)
        {
            if (id != 0)
            {
                string temp = _specialty.GetById(id).Photo;
                if (temp != null)
                    System.IO.File.Delete(Server.MapPath(temp));
                _specialty.Delete(id);
            }
            return RedirectToAction("Specialties", new { facultyId = facultyId});
        }
    }


}