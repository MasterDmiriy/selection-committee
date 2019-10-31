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
        public IEnumerable<SubjectDTO> SubjectsCertificate { get; set; }
        public IEnumerable<SubjectDTO> SubjecstEIE { get; set; }
    }
}