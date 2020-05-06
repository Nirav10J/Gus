using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cus.Business.Interface;
using Cus.BusinessEntity.ViewModels;
using Cus.Data.Interface;
using Cus.Data.Model;

namespace Cus.Business.Manager
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        public UserManager() { }

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserViewModel> GetAllUsers()
        {
            List<UserViewModel> userViewModel = new List<UserViewModel>();
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<tblCustomer, UserViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                var source = new tblCustomer();
                source = user;
                var dest = mapper.Map<tblCustomer, UserViewModel>(source);
                userViewModel.Add(dest);
            }
            return userViewModel;
        }
        public UserViewModel GetUser(int id)
        {
            tblCustomer user = _userRepository.GetUser(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblCustomer, UserViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = user;
            var dest = mapper.Map<tblCustomer, UserViewModel>(source);

            return dest;
        }

        //Functions
        public string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                ).Replace('"', ' ');
        }


        public List<CityViewModel> getCity()
        {
            List<CityViewModel> cityViewModel = new List<CityViewModel>();
            var city = _userRepository.getCity();
            foreach (var cities in city)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<tblCity, CityViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                var source = new tblCity();
                source = cities;
                var dest = mapper.Map<tblCity, CityViewModel>(source);
                cityViewModel.Add(dest);
            }
            return cityViewModel;
        }


        public List<StateViewModel> getState()
        {
            List<StateViewModel> stateViewModel = new List<StateViewModel>();
            var state = _userRepository.getState();
            foreach (var states in state)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<tblState, StateViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                var source = new tblState();
                source = states;
                var dest = mapper.Map<tblState, StateViewModel>(source);
                stateViewModel.Add(dest);
            }
            return stateViewModel;
        }



        public bool Insertuser(UserViewModel customer)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserViewModel, tblCustomer>();
            });

            IMapper mapper = config.CreateMapper();
            var source = customer;
            var dest = mapper.Map<UserViewModel, tblCustomer>(source);

            bool status = _userRepository.InsertUser(dest);
            return status;
        }
        //public string CheckUserEmail(string chkemail)
        //{
        //    UserViewModel userViewModel = new UserViewModel();
        //    var status = _userRepository.CheckUserEmail(chkemail);
        //    //!userViewModel.Email.Equals(chkemail, StringComparison.CurrentCultureIgnoreCase);
        //    return status;
        //}

        public bool CheckUserEmail(string chkemail)
        {
            // UserViewModel userViewModel = new UserViewModel();
            bool status = _userRepository.CheckUserEmail(chkemail);
            //!userViewModel.Email.Equals(chkemail, StringComparison.CurrentCultureIgnoreCase);
            return status;
        }


        public bool AuthorizeUser(string Email, string Password)
        {
            bool status = _userRepository.AuthorizeUser(Email, Password);
            return status;
        }

        public bool UpdateUserPassword(string Email, string Password)
        {
            bool status = _userRepository.UpdateUserPassword(Email, Password);
            return status;
        }
        public bool UpdateUser(String email)
        {
            tblCustomer customer = _userRepository.GetUser(email);
            customer.EmailVerify = true;
            bool status = _userRepository.UpdateUser(customer);
            return status;
        }
        public UserViewModel GetById(int id)
        {
            //var p=0;
            UserViewModel user = new UserViewModel();
            //ProductViewModel customerViewModel = new ProductViewModel();
            var users = _userRepository.GetById(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblCustomer, UserViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new tblCustomer();
            source = users;
            UserViewModel dest = mapper.Map<tblCustomer, UserViewModel>(source);
            user = dest;
            return user;

        }
        public bool Edit(UserViewModel user)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, tblCustomer>();
            });
            IMapper mapper = config.CreateMapper();
            var source = user;
            var dest = mapper.Map<UserViewModel, tblCustomer>(source);

            bool status = _userRepository.UpdateUser(dest);
            return status;
        }
    }
}
