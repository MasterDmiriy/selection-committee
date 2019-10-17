using SelectionCommittee.BLL.DataTransferObject;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface ICertificateService
    {
        void Create(CertificateDTO certificate);
    }
}