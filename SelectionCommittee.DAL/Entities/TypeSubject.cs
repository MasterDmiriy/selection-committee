using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Entities
{
    public class TypeSubject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}