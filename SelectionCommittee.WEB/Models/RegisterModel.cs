using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.WEB.Models
{
    public class RegisterModel
    {
        [Required]
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

        public int RegionId { get; set; }
        [Required]
        public int EducationalInstitutionId { get; set; }
    }
}