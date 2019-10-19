using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.EntityFramework
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new DbInitializer());
        }
        public ApplicationContext(string strConnection) : base(strConnection) { }

        public DbSet<Enrollee> Enrollees { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<MarkEIE> MarkEIEs { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Statement> Statements { get; set; }

        public DbSet<SubjectCertificate> SubjectCertificates { get; set; }

        public DbSet<SubjectEIE> SubjectEIEs { get; set; }

        public  DbSet<MarkSubjectCertificate> MarkSubjectCertificates { set; get; }
    }
}
