using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Specialty> Specialties { get; set; }

        public Faculty()
        {
            Specialties = new List<Specialty>();
        }
    }
}
