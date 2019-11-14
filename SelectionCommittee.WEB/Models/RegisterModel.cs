using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Электронная почта должна быть введена")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль должен быть введен")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Имя должно быть введено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия должна быть введена")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Отчество должно быть введено")]
        public string Patronymic { get; set; }

        public int CityId { get; set; }

        [Required(ErrorMessage = "Область должна быть выбрана")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Образовательное учреждение должно быть выбрано")]
        public int EducationalInstitutionId { get; set; }

        public IEnumerable<CityDTO> Cities { set; get; }
        public IEnumerable<RegionDTO> Regions { get; set; }
        public IDictionary<string,IEnumerable<EducationalInstitutionDTO>> EducationalInstitutions { set; get; }
    }
}