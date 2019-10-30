using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class DisplayFaculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Subjects { get; set; }

        public int CountSpeciality { get; set; }
        public DisplayFaculty()
        {
            Subjects = new List<string>();
        }
    }
}