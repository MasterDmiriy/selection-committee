using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SelectionCommittee.BLL.Interfaces
{
    public interface ISpecialtyService
    {
        IEnumerable<SpecialtyDTO> GetAll();

        SpecialtyDTO GetById(int id);

        IEnumerable<SpecialtyDTO> GetByFacultyId(int facultyDTOId);

        void Delete(int id);

        void Update(SpecialtyDTO specialtyDTO);

        void Create(SpecialtyDTO specialtyDTO);

        bool IsAvailable(string enrolleeId, int specialtyId);
    }
}
