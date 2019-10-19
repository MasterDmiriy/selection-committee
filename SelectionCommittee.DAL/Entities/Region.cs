using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Entities
{
    public class Region
    {
        [Key]
        public int Id { set; get; }
        public string Name { get; set; }
        public IList<City> Cities { get; set; }

        public Region()
        {
            Cities = new List<City>();
        }
    }
}
