using System.Collections.Generic;
using SelectionCommittee.BLL.DataTransferObject;
using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.WEB.Models
{
    public class InfoAboutUser
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Область")]
        public string Region { get; set; }

        [Display(Name = "Образовательное учереждение")]
        public string EducationalInstitution { get; set; }

        public IDictionary<string,int> MarkCertificate { set; get; }
        public IDictionary<string, int> MarkEIE { get; set; }

    }
}