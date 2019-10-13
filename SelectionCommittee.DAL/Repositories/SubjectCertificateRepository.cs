using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class SubjectCertificateRepository : ISubjectCertificateRepository
    {
        private ApplicationContext _context;

        public SubjectCertificateRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<SubjectCertificate> GetAll()
        {
           return _context.SubjectCertificates.ToList();
        }
    }
}