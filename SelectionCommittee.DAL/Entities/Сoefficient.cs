using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Entities
{
    public class Сoefficient
    {
        [Key]
        public string Id { get; set; }

        public double Value { get; set; }
    }
}