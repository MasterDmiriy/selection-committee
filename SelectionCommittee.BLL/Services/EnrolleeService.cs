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
    }
}