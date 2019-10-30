using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        public int CityId { get; set; }

        [Required]
        public int RegionId { get; set; }
        [Required]
        public int EducationalInstitutionId { get; set; }

        public IEnumerable<CityDTO> Cities { set; get; }
        public IEnumerable<RegionDTO> Regions { get; set; }
        public IDictionary<string,IEnumerable<EducationalInstitutionDTO>> EducationalInstitutions { set; get; }
    }
}