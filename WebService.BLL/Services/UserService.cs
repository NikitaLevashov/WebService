using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.BLL.Interfaces;
using WebService.BLL.Mapping;
using WebService.BLL.ModelsBLL;
using WebService.DAL.Interfaces;

namespace WebService.BLL.Services
{
    public class UserService : IUserService
    {
        IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public void Create(UserBLL user)
        {
            _repository.Create(user.MapToDALUser());
        }

        public void Delete(UserBLL user)
        {
            _repository.Delete(user.MapToDALUser());
        }

        public UserBLL GetById(int id)
        {
            return _repository.Get(id).MapToBLLUser();
        }

        public IEnumerable<UserBLL> GetAll()
        {
            return _repository.GetAll().MapToEnumerableBLLUsers();
        }

        public void Update(UserBLL user)
        {
            _repository.Update(user.MapToDALUser());
        }
    }
}
