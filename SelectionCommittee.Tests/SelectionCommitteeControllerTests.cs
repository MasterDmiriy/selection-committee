using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.WEB.Controllers;
using System.Web.Mvc;
using SelectionCommittee.WEB.Models;
using System.Web;

namespace SelectionCommittee.Tests
{
    [TestClass]
    public class SelectionCommitteeControllerTests
    {
        [TestMethod]
        public void TestFaculty()
        {
            var mock = new Mock<IServiceCreator>();
            var faculty = new FacultyDTO() {Id = 1, Name = "Dima"};
            mock.Setup(m => m.CreateFacultyService().GetById(1)).Returns(faculty);
            mock.Setup(m => m.CreateSubjectService().GetSubjectsNamesEIE(faculty.FacultySubjects)).Returns(new List<string>());
            mock.Setup(m => m.CreateSpecialtyService().GetByFacultyId(1)).Returns(new List<SpecialtyDTO>());

            SelectionCommitteeController controller = new SelectionCommitteeController(mock.Object);

            var result = (controller.Faculty(1) as ViewResult).Model as DisplayFullFaculty;

            Assert.AreEqual(result.Name, "Dima");

        }

        [TestMethod]
        public void TestCreateStatement()
        {
            var mock = new Mock<IServiceCreator>();
            var statement = new StatementDTO()
            {
                Priority = 1,
                SpecialtyId = 1,
                EnrolleeId = "1"
            };

            var temp = new List<MarkSubjectDTO>(Enumerable.Range(1, 20)
                .Select(mark => new MarkSubjectDTO()));
            temp.AddRange(Enumerable.Range(1, 3)
                .Select(mark => new MarkSubjectDTO() { Mark = 100 }));
            var Priorities = new List<int>() {2, 3, 4};
            var displayStatementSubjects = new DisplayStatementSubjects()
            {
                MarkSubjects = temp,
                FacultyId = 1,
                HasEIE = false,
                Priority = 1,
                SpecialtyId = 1,
                Priorities = Priorities
            };
            mock.Setup(m => m.CreateStatementService().Create(statement));
            mock.Setup(m => m.CreateStatementService().GetFreePrioritiesByEnrollee("1")).Returns(Priorities);
            mock.Setup(m => m.CreateSubjectService().GetCertificates()).Returns(new List<SubjectDTO>());
            mock.Setup(m => m.CreateSubjectService().GetSubjectsEIEByFacyltyId(1)).Returns(new Dictionary<int, IList<SubjectDTO>>());
            mock.Setup(m => m.CreateEnrolleService().UpdateMarkSubjects("1", displayStatementSubjects.MarkSubjects));

            var claim = new Claim("Id", "1");
            var mockIdentity =
                Mock.Of<ClaimsIdentity>(ci => ci.FindFirst(It.IsAny<string>()) == claim);
            var mockContext = Mock.Of<ControllerContext>(cc => cc.HttpContext.User == mockIdentity);
            var controller = new SelectionCommitteeController(mock.Object)
            {
                ControllerContext = mockContext,
            };
           // SelectionCommitteeController controller = new SelectionCommitteeController(mock.Object);
            

            var result = controller.Statement(displayStatementSubjects) as ViewResult;

            Assert.AreEqual("Statement", result.ViewName);

        }
    }
}
