namespace SelectionCommittee.BLL.DataTransferObject
{
    public class EnrolleeDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Photo { get; set; }
        public string Role { get; set; }

        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int EducationalInstitutionId { get; set; }
        public int? CertificateId { get; set; }
    }
}