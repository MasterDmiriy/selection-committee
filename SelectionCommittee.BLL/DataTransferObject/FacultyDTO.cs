using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.DataTransferObject
{
    public class FacultyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SubjectEIEDTO FirstSubjectEIE { get; set; }

        public SubjectEIEDTO SecondSubjectEIE { get; set; }

        public SubjectEIEDTO ThirdSubjectEIE { get; set; }

        public SubjectEIEDTO FourthSubjectEIE { get; set; }
    }
}
