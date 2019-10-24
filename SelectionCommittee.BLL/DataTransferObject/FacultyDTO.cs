using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.DataTransferObject
{
    public class FacultyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SubjectDTO FirstSubjectEIE { get; set; }

        public SubjectDTO SecondSubjectEIE { get; set; }

        public SubjectDTO ThirdSubjectEIE { get; set; }

        public SubjectDTO FourthSubjectEIE { get; set; }
    }
}
