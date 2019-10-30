namespace SelectionCommittee.WEB.Models
{
    public class DisplaySpecialty
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public string Name { get; set; }

        public int BudgetPlaces { get; set; }

        public int TotalPlaces { get; set; }

        public string Description { get; set; }

        public int FacultyId { get; set; }
    }
}