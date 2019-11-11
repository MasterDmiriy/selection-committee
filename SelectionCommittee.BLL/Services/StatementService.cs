using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectionCommittee.BLL.Services
{
    public class StatementService : IStatementService
    {
        private IUnitOfWork _database;

        public StatementService(IUnitOfWork db)
        {
            _database = db;
        }

        public void Create(StatementDTO statementDTO)
        {
            _database.StatementRepository.Create(new Statement
            {
                EnrolleeId = statementDTO.EnrolleeId,
                SpecialtyId = statementDTO.SpecialtyId,
                Priority = statementDTO.Priority
            });
            _database.Save();
        }

        public IEnumerable<EnrolleeDTO> GetEnrolleeBySpecialtyId(int specialtyDTOId)
        {
            var enrollees = _database.StatementRepository.GetAll().
                Where(state => state.SpecialtyId == specialtyDTOId).
                Select(state => state.Enrollee);
            List<EnrolleeDTO> enrolleesDTO = new List<EnrolleeDTO>();
            foreach (var enrollee in enrollees)
            {
                enrolleesDTO.Add(new EnrolleeDTO
                {
                    Id = enrollee.Id,
                    Name = enrollee.Name,
                    Surname = enrollee.Surname,
                    Patronymic = enrollee.Patronymic,
                    Photo = enrollee.Photo,
                    RegionId = enrollee.RegionId,
                    CityId = enrollee.CityId,
                    EducationalInstitutionId = enrollee.EducationalInstitutionId
                });
            }

            return enrolleesDTO;

        }

        public IEnumerable<int> GetFreePrioritiesByEnrollee(string enrolleeId)
        {
           return (new List<int>{1,2,3,4}).Except(_database.StatementRepository.GetAll().Where(statement => statement.EnrolleeId == enrolleeId)
                .Select(state => state.Priority));
        }

        public  void FormStatement()
        {
            var statement = _database.StatementRepository.GetAll().GroupBy(state => state.SpecialtyId);
            foreach (var specialtyKey in statement)
            {
                foreach (var statementSpec in specialtyKey)
                {
                    var enrollees = GetEnrolleeBySpecialtyId(specialtyKey.Key);
                    var specialty = _database.SpecialtyRepository.Get(specialtyKey.Key);
                    if (enrollees.Count() != 0)
                    {
                        var result = enrollees.Select(enr => new
                        {
                            FullName = enr.Surname + " " + enr.Name + " " + enr.Patronymic,
                            Average = TransferCertificate(enr.MarkSubjectsDTO),
                            MarkSubjects = GetMarkSubjectEIE(specialtyKey.Key, enr.Id)
                        }).OrderByDescending(obj=>obj.Average);
                        int i;
                        for(i=0;i<specialty.BudgetPlaces;i++)
                        {

                        }
                        foreach (var enrollee in enrollees)
                        {
                            
                        }
                    }
                }
            }
        }

        private double EnrolleeCalculate(int firstMark, int secondMark, int thirdMark, int averageMark)
        {
            return 0;
        }

        private int TransferCertificate(IEnumerable<MarkSubjectDTO> markSubjectsDTO)
        {
            double averageMark = Math.Round(markSubjectsDTO
                             .Where(mark => mark.Mark <= 12)
                             .Average(mark => mark.Mark), 1, MidpointRounding.AwayFromZero);
            //(average - 1)*10+90 => (average + 8)*10
            return averageMark >= 2 ? (int)((averageMark + 8) * 10) : 100;
        }

        private IEnumerable<MarkSubjectDTO> GetMarkSubjectEIE(int specialtyDTOId, string enrolleeId)
        {
            SubjectService subjectService = new SubjectService(_database);
            var subject = subjectService.GetSubjectsEIEByFacyltyId(_database.SpecialtyRepository
                .Get(specialtyDTOId).FacultyId);
            List<MarkSubjectDTO> markSubjectsDTO = new List<MarkSubjectDTO>(),
                temp = new List<MarkSubjectDTO>();
            var enrollee = _database.EnrolleeManager.Get(enrolleeId);
            foreach (var mark in subject)
            {
                foreach(var subjectDTO in mark.Value)
                {
                    temp.Add(enrollee.MarkSubjects.Where(markSub => markSub.SubjectId == subjectDTO.Id)
                        .Select(markSub=>new MarkSubjectDTO
                        {
                            EnrolleeId = markSub.EnrolleeId,
                            Mark = markSub.Mark,
                            SubjectId = markSub.SubjectId
                        }).FirstOrDefault());
                }
                markSubjectsDTO.Add(temp.OrderByDescending(markSub => markSub.Mark).FirstOrDefault());
            }
            return markSubjectsDTO;
        }
    }
}
