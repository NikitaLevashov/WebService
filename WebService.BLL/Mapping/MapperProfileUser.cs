using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.BLL.ModelsBLL;
using WebService.DAL.Models;

namespace WebService.BLL.Mapping
{
    public static class MapperProfileUser
    {
        public static User MapToDALUser(this UserBLL userBL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<UserBLL, User>());
            var mapper = new Mapper(configMapper);

            var userDAL = mapper.Map<UserBLL, User>(userBL);

            return userDAL;
        }

        public static UserBLL MapToDALUser(this User userDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<User, UserBLL>());
            var mapper = new Mapper(configMapper);

            var userBLL = mapper.Map<User, UserBLL>(userDAL);

            return userBLL;
        }

        public static IEnumerable<UserBLL> MapToEnumerableBLLUsers(IEnumerable<User> usersDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<User, UserBLL>());
            var mapper = new Mapper(configMapper);

            var usersBLL = mapper.Map<IEnumerable<User>, IEnumerable<UserBLL>>(usersDAL);

            return usersBLL;
        }

        public static IEnumerable<User> MapToEnumerableBLLUsers(IEnumerable<UserBLL> usersBLL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<UserBLL, User>());
            var mapper = new Mapper(configMapper);

            var usersDAL = mapper.Map<IEnumerable<UserBLL>, IEnumerable<User>>(usersBLL);

            return usersDAL;
        }       
    }
}
