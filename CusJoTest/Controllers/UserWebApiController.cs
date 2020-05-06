using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cus.Business.Interface;
using Cus.BusinessEntity.ViewModels;
namespace CusJoTest.Controllers
{
    public class UserWebApiController : ApiController
    {
        private IUserManager _userManager;

        public UserWebApiController() { }

        public UserWebApiController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IHttpActionResult GetAllUsers()
        {
            var users = _userManager.GetAllUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userManager.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public bool InsertUser(UserViewModel userViewModel)
        {
            return _userManager.Insertuser(userViewModel);
        }

        public List<CityViewModel> GetCity()
        {
            var users = _userManager.getCity();
            
            int count = users.Count;
            return users;
        }
        [HttpGet]
        public IHttpActionResult UpdateUser(string Email)
        {
            bool status = _userManager.UpdateUser(Email);
            if (status == false)
            {
                return BadRequest();
            }
            return Ok(status);
        }


        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var GetId = _userManager.GetById(id);
            if (GetId == null)
            {
                return NotFound();
            }
            return Ok(GetId);
        }

        [HttpPost]
        public IHttpActionResult Edit(UserViewModel user)
        {
            if (user == null)
            {
                return BadRequest("invalid data");
            }
            else
            {
                if (_userManager.Edit(user))
                {
                    return Ok();
                }
                return NotFound();
            }
        }

        public IHttpActionResult GetState()
        {
            var customers = _userManager.getState();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        [HttpGet]
        public IHttpActionResult CheckEmail(string chkemail)
        {
            var customers = _userManager.CheckUserEmail(chkemail);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult CheckUserEmail(string chkemail)
        {
            //var customers = _userManager.CheckUserEmail(chkemail);
            if (chkemail == null)
            {
                return BadRequest("invalid data");
                // return NotFound();
            }
            else
            {
                if (_userManager.CheckUserEmail(chkemail))
                {
                    return Ok();
                }
                return NotFound();
            }
            //return Ok(customers);

        }
        [HttpGet]
        public IHttpActionResult AuthorizeUser([FromUri]string Email, [FromUri] string Password)
        {
            Password.ToString().Trim('"');
            if (Email == null)
            {
                return BadRequest("invalid data");
            }
            else
            {
                if (_userManager.AuthorizeUser(Email, Password))
                {
                    return Ok();
                }
                return NotFound();
            }
            
        }

        [HttpGet]
        public bool UpdateUserPassword([FromUri]string Email, [FromUri] string Password)
        {
            //var hasepassword= _userManager.Hash(Password);
            return _userManager.UpdateUserPassword(Email, Password);
        }

        [HttpGet]
        public string HasePassword([FromUri]string password)
        {
            return _userManager.Hash(password);
        }


    }
}
