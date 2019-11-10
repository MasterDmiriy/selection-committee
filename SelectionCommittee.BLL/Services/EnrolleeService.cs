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
           }).Where(mark => mark.Mark != 0).ToList();


           if (enrollee.MarkSubjects.Count == 0)
               enrollee.MarkSubjects = markSubjects;
           else
           {
               (from mark in markSubjects
                       where enrolleeMarkEIE
                                 .Count(obj => obj.SubjectId == mark.SubjectId) == 0
                       select mark).ToList()
                   .ForEach(markSubject => enrollee.MarkSubjects.Add(markSubject));
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

        public EnrolleeDTO Get(string id)
        {
            var enrollee = _database.EnrolleeManager.Get(id);
            return new EnrolleeDTO()
            {
                Name = enrollee.Name,
                Surname = enrollee.Surname,
                Patronymic = enrollee.Patronymic,
                Email = enrollee.ApplicationUser.Email,
                City = enrollee.City.Name,
                Region = enrollee.Region.Name,
                EducationalInstitution = enrollee.EducationalInstitution.Name
            };
        }

        public IDictionary<string, int> GetMarkSubjectCertificate(string id)
        {
            var MarkSubjects = new Dictionary<string, int>();
            var result = _database.EnrolleeManager.Get(id).MarkSubjects.Where(mark => mark.Mark < 100);
            foreach (var markSubject in result)
            {
                MarkSubjects.Add(markSubject.Subject.Name, markSubject.Mark);
            }

            return MarkSubjects;
        }

        public IDictionary<string, int> GetMarkSubjectEIE(string id)
        {
            var MarkSubjects = new Dictionary<string, int>();
            var result = _database.EnrolleeManager.Get(id).MarkSubjects.Where(mark => mark.Mark >= 100);
            foreach (var markSubject in result)
            {
                MarkSubjects.Add(markSubject.Subject.Name, markSubject.Mark);
            }

            return MarkSubjects;
        }
    }
}