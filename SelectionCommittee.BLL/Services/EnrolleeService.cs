using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SelectionCommittee.BLL.DataTransferObject;
using SelectionCommittee.BLL.Infrastructure;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    public class EnrolleeService : IEnrolleeService
    {
        private IUnitOfWork _database;

        public EnrolleeService(IUnitOfWork db)
        {
            _database = db;
        }
        public async Task<OperationDetails> Create(EnrolleeDTO enrollee)
        {
            //var role = await _database.RoleManager.FindByNameAsync(enrollee.Role);
            //if (role == null)
            //{
            //    role = new ApplicationRole { Name = enrollee.Role };
            //    await _database.RoleManager.CreateAsync(role);
            //}
            ApplicationUser user = await  _database.UserManager.FindByEmailAsync(enrollee.Email);
           if (user == null)
           {
               user = new ApplicationUser {Email = enrollee.Email, UserName = enrollee.UserName};
               var result = await _database.UserManager.CreateAsync(user, enrollee.Password);
               if(result.Errors.Any())
                   return new OperationDetails(false, result.Errors.FirstOrDefault(),"");
               await _database.UserManager.AddToRoleAsync(user.Id, enrollee.Role);
               Enrollee enrol = new Enrollee
               {
                   Id = user.Id,
                   Name = enrollee.Name, Surname = enrollee.Surname, Patronymic = enrollee.Patronymic, 
                   CityId = enrollee.CityId, RegionId = enrollee.RegionId,
                   EducationalInstitutionId = enrollee.EducationalInstitutionId
               };
               _database.EnrolleeManager.Create(enrol);
                await _database.SaveAsync();
               return new OperationDetails(true,"Регистрация успешно пройдена", "");
           }
           else
           {
               return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
           }
        }

        public OperationDetails Update(EnrolleeDTO enrollee)
        {
            Enrollee enrol = new Enrollee
            {
                Id = enrollee.Id,
                Name = enrollee.Name,
                Surname = enrollee.Surname,
                Patronymic = enrollee.Patronymic,
                Photo = enrollee.Photo,
                CityId = enrollee.CityId,
                RegionId = enrollee.RegionId,
                EducationalInstitutionId = enrollee.EducationalInstitutionId
            };
            _database.EnrolleeManager.Update(enrol);
            return new OperationDetails(true,"Данные успешно обновлены","");
        }

        public void UpdateMarkSubjects(string id, IEnumerable<MarkSubjectDTO> markSubjectsDTO)
        {
           var enrollee = _database.EnrolleeManager.Get(id);
           var enrolleeMarkEIE = GetMarkSubjectsEIE(id);
           IList<MarkSubject> markSubjects = markSubjectsDTO.Select(mark => new MarkSubject
           {
               SubjectId = mark.SubjectId,
               Mark = mark.Mark
           }).ToList();

           var resultMark = (from mark in markSubjects
               where enrolleeMarkEIE
                         .Count(obj => obj.SubjectId == mark.SubjectId) == 0
               select mark).ToList();

           if (enrollee.MarkSubjects.Count == 0)
               enrollee.MarkSubjects = markSubjects;
           else
           {
               foreach (var markSubject in resultMark)
               {
                   enrollee.MarkSubjects.Add(markSubject);
               }
           }

           _database.EnrolleeManager.Update(enrollee);
            _database.Save();
        }

        public async Task<ClaimsIdentity> Authenticate(EnrolleeDTO enrollee)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _database.UserManager.FindAsync(enrollee.UserName, enrollee.Password);
            if (user != null)
            {
                claim = await _database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<MarkSubjectDTO> GetMarkSubjectsEIE(string id)
        {
            return _database.EnrolleeManager.Get(id).MarkSubjects.Select(mark=> new MarkSubjectDTO
            {
                SubjectId = mark.SubjectId,
                Mark = mark.Mark,
                EnrolleeId = mark.EnrolleeId
            }).Where(mark=>mark.Mark>=100);
        }
    }
}