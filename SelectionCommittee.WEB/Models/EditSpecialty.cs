namespace SelectionCommittee.WEB.Models
{
    public class EditSpecialty
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public string Name { get; set; }

        public int BudgetPlaces { get; set; }

        public int TotalPlaces { get; set; }

        public string Description { get; set; }

        public int FacultyId { get; set; }
        public string Photo { get; set; }
    }
}