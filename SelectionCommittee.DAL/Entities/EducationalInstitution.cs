using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class EducationalInstitution
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public City City { get; set; }
        [ForeignKey("City")]
        public int CityId { set; get; }
    }
}
