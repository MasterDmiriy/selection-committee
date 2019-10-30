using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.WEB.Models
{
    public class CreateFaculty
    {
        [Required(ErrorMessage = "Название факультета должно быть установлено")]
        [StringLength(70,MinimumLength = 7,ErrorMessage = "Название факультета должно быть не менее 7 и не более 70")]
        public string Name { set; get; }

        public IList<SubjectDTO> Subjects { set; get; }

        [Required(ErrorMessage = "Описание факультета должно быть установлено")]
        public string Description { get; set; }

        public CreateFaculty()
        {
            Subjects = new List<SubjectDTO>();
        }
    }
}