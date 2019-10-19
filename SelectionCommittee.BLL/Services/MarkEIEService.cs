using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.Services
{
    public class MarkEIEService : IMarkEIEService
    {
        private IUnitOfWork _database;

        public MarkEIEService(IUnitOfWork db)
        {
            _database = db;
        }

        public void CreateRange(IEnumerable<MarkEIEDTO> marksEIEDTO)
        {
            List<MarkEIE> marksEIE = new List<MarkEIE>();
            foreach(var markEIE in marksEIEDTO)
            {
                marksEIE.Add(new MarkEIE
                {
                    EnrolleeId = markEIE.EnrolleeId,
                    SubjectEIEId = markEIE.SubjectEIEId,
                    Mark = markEIE.Mark
                });
            }
            _database.MarkEIERepository.CreateRange(marksEIE);
            _database.Save();
        }
    }
}
