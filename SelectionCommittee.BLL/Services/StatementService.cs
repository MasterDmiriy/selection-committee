using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using SelectionCommittee.BLL.Infrastructure;

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

        public void FormStatement(string path)
        {
            var statement = _database.StatementRepository.GetAll().GroupBy(state => state.Specialty)
                .Select(state => new
                {
                    SpecialtyState = state.Key,
                    Statements = state.Select(st=>st)
                });
            foreach (var specialtyKey in statement)
            {
                var report = new List<Report>();
                var enrolleeService = new EnrolleeService(_database);
                var specialty = specialtyKey.SpecialtyState;
                var subjects = new SubjectService(_database)
                    .GetSubjectsNamesEIE(new FacultyService(_database).GetById(specialty.FacultyId).FacultySubjects)
                    .ToList();
                foreach (var statementSpec in specialtyKey.Statements)
                {

                    var enrollee = new EnrolleeService(_database).Get(statementSpec.EnrolleeId);
                    
                    report.Add(new Report
                    {
                        FullName = enrollee.Surname + " " + enrollee.Name + " " + enrollee.Patronymic,
                        Certificate = TransformCertificate(enrollee.MarkSubjectsDTO),
                        MarkSubjects = GetMarkSubjectEIE(specialtyKey.SpecialtyState.Id, enrollee.Id).ToList(),
                        RuralCoefficient = enrolleeService.isRuralCoefficient(enrollee.Id) ? 1.02 : 1,
                        PriorityCoefficient = statementSpec.Priority > 2 ? 1 : 1.02
                    });

                }
                Application ex = new Application();

                //Отобразить Excel
                ex.Visible = false;
                ex.SheetsInNewWorkbook = 1;
                Workbook workBook = ex.Workbooks.Add(Type.Missing);

                //Отключить отображение окон с сообщениями
                ex.DisplayAlerts = false;
                Worksheet sheet = (Worksheet)ex.Worksheets.Item[1];

                sheet.Name = "Список абитуриентов";

                sheet.Range[sheet.Cells[2, 3], sheet.Cells[2, 3]].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(153, 238, 153));
                sheet.Cells[2, 3] = "Бюджетное место";

                sheet.Cells[3, 2] = "№";
                sheet.Cells[3, 3] = "ФИО";
                sheet.Cells[3, 4] = "Аттестат";
                sheet.Cells[3, 5] = "Украинский язык и литература";
                sheet.Cells[3, 6] = "Иностранный язык или физика";
                sheet.Cells[3, 7] = "Математика или биология";
                sheet.Cells[3, 8] = "Балл";

                report = report.OrderByDescending(obj => obj.Certificate).ToList();
                int i, j;
                for (i = 0, j = 4; i < specialty.TotalPlaces && i < report.Count; i++, j++)
                {
                    //if(i< specialty.BudgetPlaces)
                    sheet.Cells[j, 2] = i + 1;
                    sheet.Cells[j, 3] = report[i].FullName;
                    sheet.Cells[j, 4] = report[i].Certificate;
                    sheet.Cells[j, 5] = report[i].MarkSubjects[0].Mark;
                    sheet.Cells[j, 6] = report[i].MarkSubjects[1].Mark;
                    sheet.Cells[j, 7] = report[i].MarkSubjects[2].Mark;
                    sheet.Cells[j, 8] = EnrolleeCalculate(report[i].MarkSubjects[0].Mark,
                        report[i].MarkSubjects[1].Mark, report[i].MarkSubjects[2].Mark,
                        report[i].Certificate, report[i].RuralCoefficient, report[i].PriorityCoefficient);
                }

                //Захватываем диапазон ячеек
                Range rng = sheet.Range[sheet.Cells[3, 2], sheet.Cells[9, 8]];
                rng.WrapText = true;
                rng.EntireRow.AutoFit();
                rng.EntireColumn.AutoFit();
                rng.Cells.Font.Size = 10;
                rng.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                Borders border = rng.Borders;
                border.LineStyle = XlLineStyle.xlContinuous;

                var colorRange = sheet.Range[sheet.Cells[4, 2], sheet.Cells[9, 8]];
                colorRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(153, 238, 153));


                sheet.Range[sheet.Cells[3, 3], sheet.Cells[9, 3]].ColumnWidth = 20;
                sheet.Range[sheet.Cells[3, 5], sheet.Cells[9, 5]].ColumnWidth = 16;
                sheet.Range[sheet.Cells[3, 6], sheet.Cells[9, 7]].ColumnWidth = 14;

                ex.Application.ActiveWorkbook.SaveAs(path+specialty.Name+ ".xlsx", Type.Missing,
                    Type.Missing, Type.Missing, false,
                    Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                workBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path + specialty.Name + ".pdf");
            }
        }

        private double EnrolleeCalculate(int firstMark, int secondMark, int thirdMark, int certificateMark,
            double ruralCoefficient, double priorityCoefficient)
        {
            var coefficients = _database.CoefficientRepository.GetAll().ToList();
            double passMark = Math.Round((firstMark * coefficients[0].Value + secondMark * coefficients[1].Value +
                                          thirdMark * coefficients[2].Value
                                          + certificateMark * coefficients[3].Value) *
                                         (ruralCoefficient * priorityCoefficient),
                2,
                MidpointRounding.AwayFromZero);
            return passMark > 200 ? 200 : passMark;
        }

        private int TransformCertificate(IEnumerable<MarkSubjectDTO> markSubjectsDTO)
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
                foreach (var subjectDTO in mark.Value)
                {
                    temp.Add(enrollee.MarkSubjects
                        .Where(markSub => markSub.SubjectId == subjectDTO.Id && markSub.Mark >= 100)
                        .Select(markSub => new MarkSubjectDTO
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
