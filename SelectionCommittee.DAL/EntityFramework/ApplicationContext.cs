using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.EntityFramework
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationContext(string strConnection) : base(strConnection) { }
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Region>().HasMany(r=>r.Cities)
                .WithRequired(r=>r.Region).HasForeignKey(r=>r.RegionId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Region>().HasMany(c=>c.EducationalInstitutions)
                .WithRequired(c=>c.Region).HasForeignKey(c=>c.RegionId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<City>().HasMany(c=>c.Enrollees).
                WithRequired(c=>c.City).HasForeignKey(c=>c.CityId).
                WillCascadeOnDelete(false);
            modelBuilder.Entity<Region>().HasMany(r=>r.Enrollees)
                .WithRequired(r=>r.Region).HasForeignKey(r=>r.RegionId)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Enrollee> Enrollees { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Statement> Statements { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public  DbSet<MarkSubject> MarkSubjects { set; get; }

        public DbSet<TypeSubject> TypeSubjects { get; set; }
        public DbSet<FacultySubject> FacultySubjects { set; get; }
    }
}
