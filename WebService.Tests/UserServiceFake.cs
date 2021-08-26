using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.BLL.Interfaces;
using WebService.Mapping;
using WebService.BLL.ModelsBLL;
using WebService.Models;

namespace WebService.Tests
{
    public class UserServiceFake : IUserService
    {
        private readonly List<User> users;
        private readonly List<UserBLL> usersBLL;
        public UserServiceFake()
        {
            users = new List<User>()
            {
                new User {Name = "Nikita", Surname = "Ivanov", Details = new Details{ Age = 15, Adress = "London"} },
                new User { Name = "Pasha", Surname="Sidorov", Details = new Details {Age = 18, Adress = "Minsk"} },
                new User() { Name = "Dmitriy", Surname="Norov", Details = new Details {Age = 18, Adress = "Minsk"} }
            };

            usersBLL = new List<UserBLL>()
            {
                new UserBLL {Id = 1, Name = "Nikita", Surname = "Ivanov", Details = new DetailsBLL{ Id = 1, Age = 15, Adress = "London"} },
                new UserBLL {Id = 2, Name = "Pasha", Surname="Sidorov", Details = new DetailsBLL {Id = 2, Age = 18, Adress = "Minsk"} },
                new UserBLL {Id = 3, Name = "Dmitriy", Surname="Norov", Details = new DetailsBLL {Id = 3, Age = 18, Adress = "Minsk"} }
            };
        }

        public IEnumerable<UserBLL> GetAll()
        {
            return usersBLL;
        }

        public UserBLL GetById(int id)
        {
            return usersBLL.FirstOrDefault(x => x.Id == id);
        }

        public void Create(UserBLL item)
        {
            users.Add(item.MapToUser());
        }

        public void Update(UserBLL item)
        {
            var user = users.MapToEnumerableBLLUsers().FirstOrDefault(x => x.Id == item.Id);
            users.Remove(user.MapToUser());
            users.Add(item.MapToUser());
        }

        public void Delete(UserBLL item)
        {
            var user = usersBLL.FirstOrDefault(x => x.Id == item.Id);
            usersBLL.Remove(user);
        }
    }
}
