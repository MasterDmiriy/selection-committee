using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class DisplayHome
    {
        public IEnumerable<FacultyDTO> FacultiesDTO { set; get; }
    }
}