using SelectionCommittee.BLL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectionCommittee.WEB.Models
{
    public class DisplayStatementSubjects
    {
        public int SpecialtyId { get; set; }
        public int FacultyId { get; set; }
        public int Priority { get; set; }
        public IList<MarkSubjectDTO> MarkSubjects { get; set; }
        public IList<SubjectDTO> SubjectsCertificate { get; set; }
        public IDictionary<int,IList<SubjectDTO>> SubjectsEIE { get; set; }
        public List<int> Priorities { get; set; }
        public bool Flag { get; set; }
    }
}