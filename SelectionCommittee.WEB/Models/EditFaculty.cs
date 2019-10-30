using System.Collections.Generic;
using System.Web.Mvc;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class EditFaculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Photo { set; get; }

        public IList<FacultySubjectDTO> FacultySubjects { get; set; }

        public IList<SubjectDTO> Subjects { set; get; }
        public string Description { get; set; }

        public EditFaculty()
        {
            FacultySubjects = new List<FacultySubjectDTO>();
            Subjects = new List<SubjectDTO>();
        }
    }
}