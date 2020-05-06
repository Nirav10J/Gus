using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cus.Data.Interface;
using Cus.Data.Model;
namespace Cus.Data.Repository
{
   public class UserRepository : IUserRepository
    {

        private EVCdb3Entities EVCDataEntities;

        public UserRepository()
        {
            EVCDataEntities = new EVCdb3Entities();
        }

        public List<tblCustomer> GetAllUsers()
        {
            return EVCDataEntities.tblCustomers.ToList();
        }
        public tblCustomer GetUser(int id)
        {
            tblCustomer customer = EVCDataEntities.tblCustomers.Find(id);
            return customer;

        }
        public tblCustomer GetUser(string email)
        {
            tblCustomer user = EVCDataEntities.tblCustomers.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public List<tblCity> getCity()
        {
            return EVCDataEntities.tblCities.ToList();
        }

        public List<tblState> getState()
        {
            return EVCDataEntities.tblStates.ToList();
        }

        public bool InsertUser(tblCustomer customer)
        {
            bool status = false;
            EVCDataEntities.tblCustomers.Add(customer);
            if (EVCDataEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }
        public bool UpdateUser(tblCustomer customer)
        {
            bool status = false;
            EVCDataEntities.Entry(customer).State = EntityState.Modified;
            if (EVCDataEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }
        public tblCustomer GetById(int id)
        {
            return EVCDataEntities.tblCustomers.FirstOrDefault(x => x.Id == id);
        }
        //public string CheckUserEmail(string chkemail)
        //{
        //    var result = !EVCDataEntities.tblCustomers.ToList().Exists(x => x.Email.Equals(chkemail, StringComparison.CurrentCultureIgnoreCase));
        //    return result.ToString();
        //}
        public bool CheckUserEmail(string chkemail)
        {
            bool status = true;
            var result = !EVCDataEntities.tblCustomers.ToList().Exists(x => x.Email.Equals(chkemail, StringComparison.CurrentCultureIgnoreCase));
            if (result == false)
            {
                status = false;
            }
            return status;
            //return result.ToString();
        }

        public bool AuthorizeUser(string Email, string Password)
        {
            bool status = false;
            var result = EVCDataEntities.tblCustomers.ToList().Exists(x => x.Email.Equals(Email, StringComparison.CurrentCultureIgnoreCase)
                             && x.Password.Equals(Password, StringComparison.CurrentCultureIgnoreCase));
            if (result == true)
            {
                status = true;
            }
            return status;
        }

        public bool UpdateUserPassword(string Email, string Password)
        {
            bool status = false;
            tblCustomer customer = EVCDataEntities.tblCustomers.Where(x => x.Email == Email).FirstOrDefault();
            customer.Password = Password;
            EVCDataEntities.Entry(customer).State = EntityState.Modified;
            if (EVCDataEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
