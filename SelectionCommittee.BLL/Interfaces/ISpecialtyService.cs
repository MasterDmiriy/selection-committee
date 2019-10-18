using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface ISpecialtyService
    {
        IEnumerable<SpecialtyDTO> GetAll();

        SpecialtyDTO GetById(int id);

        IEnumerable<SpecialtyDTO> GetByFacultyId(int facultyDTOId);

        void Create(SpecialtyDTO specialtyDTO);
    }
}
