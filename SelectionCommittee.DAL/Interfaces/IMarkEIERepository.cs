using SelectionCommittee.DAL.Entities;
using System.Collections.Generic;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IMarkEIERepository
    {
        void CreateRange(IEnumerable<MarkEIE> marksEIE);
    }
}