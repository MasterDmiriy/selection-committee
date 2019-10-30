namespace SelectionCommittee.BLL.DataTransferObject
{
    public class EducationalInstitutionDTO
    {
        public int Id { set; get; }
        public string Name { get; set; }

        public int RegionId { set; get; }

        public bool IsCity { get; set; }
    }
}