using System.Collections.Generic;
using System.Linq;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class MarkSubjectCertificateRepository : IMarkSubjectCertificateRepository
    {
        private ApplicationContext _context;
        public MarkSubjectCertificateRepository(ApplicationContext db)
        {
            _context = db;
        }
        public void CreateRange(IEnumerable<MarkSubjectCertificate> markSubjectCertificates)
        {
            _context.MarkSubjectCertificates.AddRange(markSubjectCertificates);
        }

        public IEnumerable<MarkSubjectCertificate> GetAll()
        {
            return _context.MarkSubjectCertificates.ToList();
        }
    }
}