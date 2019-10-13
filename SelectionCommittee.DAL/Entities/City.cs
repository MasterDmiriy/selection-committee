using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Entities
{
    public class City
    {
        [Key]
        public  int Id { set; get; }
        public string Name { get; set; }
    }
}
