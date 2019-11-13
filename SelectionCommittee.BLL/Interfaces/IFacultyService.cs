using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface IFacultyService
    {
        IEnumerable<FacultyDTO> GetAll();

        FacultyDTO GetById(int id);


        void Delete(int facultyId);

        void Update(FacultyDTO facultyDTO);

        void Create(FacultyDTO facultyDTO);

        bool IsExist(int facultyDTOId);

    }
}
