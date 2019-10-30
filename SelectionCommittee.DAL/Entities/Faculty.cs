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

        public string Photo { get; set; }
        public string Description { get; set; }
        public ICollection<FacultySubject> FacultySubjects { get; set; }
        public IList<Specialty> Specialties { get; set; }

        public Faculty()
        {
            FacultySubjects = new List<FacultySubject>();
            Specialties = new List<Specialty>();
        }
    }
}
