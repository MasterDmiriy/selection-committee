using System;
using System.Collections.Generic;
using System.Text;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.EntityFramework;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    class CertificateRepository : ICertificateRepository
    {
        private ApplicationContext _context;
        public CertificateRepository(ApplicationContext db)
        {
            _context = db;
        }

        public void Create(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
        }
    }
}
