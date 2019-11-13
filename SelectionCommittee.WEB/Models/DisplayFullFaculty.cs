using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class DisplayFullFaculty
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public IList<SpecialtyDTO> SpecialtiesDTO { set; get; }
        public IEnumerable<string> Subjects { get; set; }
        public string Description { get; set; }

        public DisplayFullFaculty()
        {
            Subjects = new List<string>();
            SpecialtiesDTO = new List<SpecialtyDTO>();
        }
    }
}