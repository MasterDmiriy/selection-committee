using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Infrastructure
{
    public class Report
    {
        public string FullName { get; set; }
        public int Certificate { get; set; }

        public IList<MarkSubjectDTO> MarkSubjects { get; set; }
        public double PassMark { get; set; }
        public double RuralCoefficient { get; set; }
        public double PriorityCoefficient { get; set; }
        
    }
}