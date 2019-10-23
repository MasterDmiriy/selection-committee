using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class DefaultModel
    {
        public IEnumerable<CityDTO> Cities { set; get; }
        public IEnumerable<RegionDTO> Regions { get; set; }
        public IEnumerable<EducationalInstitutionDTO> EducationalInstitutions { set; get; }
    }
}