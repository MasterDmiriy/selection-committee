﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;
using SelectionCommittee.WEB.Models;

namespace SelectionCommittee.WEB.Controllers
{
    public class SelectionCommitteeController : Controller
    {
        private IServiceCreator _creator;
        private IFacultyService _faculty;
        private ISpecialtyService _specialty;
        private ISubjectService _subject;
        private IStatementService _statement;
        private IEnrolleeService _enrollee;

        public SelectionCommitteeController(IServiceCreator creator)
        {
            _creator = creator;
            _faculty = _creator.CreateFacultyService();
            _specialty = _creator.CreateSpecialtyService();
            _subject = _creator.CreateSubjectService();
            _statement = _creator.CreateStatementService();
            _enrollee = _creator.CreateEnrolleService();
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
                TotalPlaces = specialty.TotalPlaces,
                isAvailable = _specialty.IsAvailable(User.Identity.GetUserId(), specialty.Id)
            };
            return View(displaySpecialty);
        }

        [HttpGet]
        public ActionResult Statement(int specialtyId, int facultyId)
        {
            var SubjectsEIE = _subject.GetSubjectsEIEByFacyltyId(facultyId);
            var SubjectsCertificate = _subject.GetCertificates();
            List<MarkSubjectDTO> tempEIE = _enrollee.GetMarkSubjectsEIE(User.Identity.GetUserId()).ToList();
            List<MarkSubjectDTO> temp = new List<MarkSubjectDTO>();
            bool hasEIE = tempEIE.Any();
            if (!hasEIE)
            {
                temp = new List<MarkSubjectDTO>(Enumerable.Range(1, SubjectsCertificate.Count())
                    .Select(mark => new MarkSubjectDTO()));
                temp.AddRange(Enumerable.Range(1, 3)
                    .Select(mark => new MarkSubjectDTO() {Mark = 100}));
            }
            else
            {
                foreach (var subjectKey in SubjectsEIE)
                {
                    foreach (var subject in subjectKey.Value)
                    {
                        var buf = tempEIE.Where(t => t.SubjectId == subject.Id);
                        if (buf.Count() != 0)
                            temp.AddRange(buf);
                        else temp.Add(new MarkSubjectDTO{Mark = 100});
                    }
                }
            }

            DisplayStatementSubjects statementSubjects = new DisplayStatementSubjects
            {
                SpecialtyId = specialtyId,
                FacultyId = facultyId,
                SubjectsEIE = SubjectsEIE,
                MarkSubjects = temp,
                HasEIE = hasEIE,
                Priorities = _statement.GetFreePrioritiesByEnrollee(User.Identity.GetUserId()).ToList()
            };
            statementSubjects.SubjectsCertificate = !hasEIE ? SubjectsCertificate.ToList() : new List<SubjectDTO>();
            return View(statementSubjects);
        }

        [HttpPost]
        public ActionResult Statement(DisplayStatementSubjects displayStatementSubjects)
        {
            if (ModelState.IsValid)
            {
                if(displayStatementSubjects.MarkSubjects.Count(mark=>mark.Mark!=0)<24&&!displayStatementSubjects.HasEIE)
                    ModelState.AddModelError("","Должно быть заполнено как минимум 21 поле с оценкой аттестата");
                else
                {
                    _statement.Create(new StatementDTO
                    {
                        Priority = displayStatementSubjects.Priority,
                        SpecialtyId = displayStatementSubjects.SpecialtyId,
                        EnrolleeId = User.Identity.GetUserId()
                    });
                    _enrollee.UpdateMarkSubjects(User.Identity.GetUserId(),
                        displayStatementSubjects.MarkSubjects);
                   return RedirectToAction("Faculty", new {id = displayStatementSubjects.FacultyId});
                }
            }

            displayStatementSubjects.SubjectsCertificate = !displayStatementSubjects.HasEIE
                ?  _subject.GetCertificates().ToList() 
                : new List<SubjectDTO>(); ;
            displayStatementSubjects.SubjectsEIE = _subject.GetSubjectsEIEByFacyltyId(displayStatementSubjects.FacultyId);
            displayStatementSubjects.Priorities =
                _statement.GetFreePrioritiesByEnrollee(User.Identity.GetUserId()).ToList();
            return View(displayStatementSubjects);
        }

        public ActionResult PersonalArea()
        {
            var enrolleeDTO = _enrollee.Get(User.Identity.GetUserId());
            InfoAboutUser infoAboutUser = new InfoAboutUser()
            {
                FullName = enrolleeDTO.Surname+" "+ enrolleeDTO.Name+" "+ enrolleeDTO.Patronymic,
                Email = enrolleeDTO.Email,
                City = enrolleeDTO.City,
                Region = enrolleeDTO.Region,
                EducationalInstitution = enrolleeDTO.EducationalInstitution
            };
            infoAboutUser.MarkCertificate = _enrollee.GetMarkSubjectCertificate(User.Identity.GetUserId());
            infoAboutUser.MarkEIE = _enrollee.GetMarkSubjectEIE(User.Identity.GetUserId());
            return View(infoAboutUser);
        }
    }
}