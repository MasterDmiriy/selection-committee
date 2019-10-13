using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ICertificateRepository
    {
        void Create(Certificate certificate);
    }
}