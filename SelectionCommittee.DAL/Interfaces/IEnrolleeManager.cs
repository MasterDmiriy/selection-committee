using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IEnrolleeManager
    {
        void Create(Enrollee enrollee);
        Enrollee Get(int id);

        void Update(Enrollee enrollee);
    }
}