using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Enrollee
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public City City { get; set; }

        [ForeignKey("City")] 
        public int? CityId { get; set; }

        public Region Region { get; set; }

        [ForeignKey("Region")] 
        public int RegionId { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }

        [ForeignKey("EducationalInstitution")]
        public int EducationalInstitutionId { get; set; }

        public string Photo { get; set; }
        public Certificate Certificate { get; set; }

        [ForeignKey("Certificate")]
        public int? CertificateId { get; set; }

        public IList<MarkEIE> MarkEIEs { set; get; }

        public Enrollee()
        {
            MarkEIEs = new List<MarkEIE>();
        }
    }
}
