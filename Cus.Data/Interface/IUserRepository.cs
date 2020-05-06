using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cus.Data.Model;
namespace Cus.Data.Interface
{
   public interface IUserRepository
    {
        List<tblCustomer> GetAllUsers();
        List<tblCity> getCity();
        List<tblState> getState();
        tblCustomer GetUser(int id);
        bool InsertUser(tblCustomer customer);
        bool UpdateUser(tblCustomer customer);
        bool AuthorizeUser(string Email, string Password);
        tblCustomer GetById(int id);
        tblCustomer GetUser(String id);
        bool CheckUserEmail(string chkemail);

        bool UpdateUserPassword(string Email, string Password);
    }
}
