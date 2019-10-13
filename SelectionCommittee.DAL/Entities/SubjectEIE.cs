using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Entities
{
    //EIE - external independent evaluation
    public class SubjectEIE
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
