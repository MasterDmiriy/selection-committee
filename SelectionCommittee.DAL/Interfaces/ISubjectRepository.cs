using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface ISubjectRepository 
    {
        IEnumerable<Subject> GetCertificates();
        //EIE - extern independent evalution
        IEnumerable<Subject> GetSubjectsEIE();

    }
}