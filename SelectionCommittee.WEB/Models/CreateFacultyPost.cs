using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class CreateFacultyPost
    {
        public string Name { set; get; }

        public ICollection<FacultySubjectDTO> FacultySubjects { set; get; }

        public string Description { get; set; }
    }
}