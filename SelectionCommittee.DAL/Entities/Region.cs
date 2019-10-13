using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Entities
{
    public class Region
    {
        [Key]
        public int Id { set; get; }
        public string Name { get; set; }
    }
}
