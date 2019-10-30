using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.DataTransferObject
{
    public class FacultyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Photo { get; set; }

        public ICollection<FacultySubjectDTO> FacultySubjects { get; set; }
        public string Description { get; set; }

        public FacultyDTO()
        {
            FacultySubjects = new List<FacultySubjectDTO>();
        }
    }
}
