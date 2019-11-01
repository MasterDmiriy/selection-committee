using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionCommittee.BLL.Services
{
    public class MarkSubjectService : IMarkSubjectService
    {
        private IUnitOfWork _database;

        public MarkSubjectService(IUnitOfWork db)
        {
            _database = db;
        }


        public void CreateRange(IEnumerable<MarkSubjectDTO> markSubjectsDTO)
        {
            List<MarkSubject> markSubjects = new List<MarkSubject>();
            foreach(var markEIE in markSubjectsDTO)
            {
                markSubjects.Add(new MarkSubject
                {
                    EnrolleeId = markEIE.EnrolleeId,
                    SubjectId = markEIE.SubjectId,
                    Mark = markEIE.Mark
                });
            }
            _database.MarkSubjectRepository.CreateRange(markSubjects);
            _database.Save();
        }
    }
}
