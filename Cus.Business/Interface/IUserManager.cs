using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cus.BusinessEntity.ViewModels;
namespace Cus.Business.Interface
{
   public interface IUserManager
    {
        List<UserViewModel> GetAllUsers();
        List<CityViewModel> getCity();
        List<StateViewModel> getState();
        UserViewModel GetUser(int id);
        string Hash(string value);
        bool CheckUserEmail(string chkemail);
        bool Insertuser(UserViewModel customer);
        bool AuthorizeUser(string Email, string Password);
        bool UpdateUser(string email);
        bool Edit(UserViewModel user);
        UserViewModel GetById(int id);

        bool UpdateUserPassword(string Email, string Password);
    }
}
