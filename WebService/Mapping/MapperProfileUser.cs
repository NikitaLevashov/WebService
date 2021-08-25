using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.BLL.ModelsBLL;
using WebService.Models;

namespace WebService.Mapping
{
    public static class MapperProfileUser
    {
        public static UserBLL MapToBLLUser(this User user)
        {
            var userBLL = MapperForBLL().Map<User, UserBLL>(user);

            return userBLL;
        }

        public static User MapToUser(this UserBLL userBLL)
        {
            var user = MapperForApi().Map<UserBLL, User>(userBLL);

            return user;
        }

        public static IEnumerable<User> MapToEnumerableUsers(this IEnumerable<UserBLL> usersBLL)
        {
            var users = MapperForApi().Map<IEnumerable<UserBLL>, IEnumerable<User>>(usersBLL);

            return users;
        }

        public static IEnumerable<UserBLL> MapToEnumerableBLLUsers(this IEnumerable<User> users)
        {
            var usersBLL = MapperForBLL().Map<IEnumerable<User>, IEnumerable<UserBLL>>(users);

            return usersBLL;
        }

        private static Mapper MapperForApi()
        {
            var configMapper =
              new MapperConfiguration(config => config.CreateMap<UserBLL, User>().
          ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
          ForMember(dest => dest.Surname, opt => opt.MapFrom(c => c.Surname)).
          ForMember(dest => dest.Details, map => map.MapFrom(
              source => new Details
              {
                  Age = source.Details.Age,
                  Adress = source.Details.Adress,
              })));

            return new Mapper(configMapper);
        }

        private static Mapper MapperForBLL()
        {
            var configMapper =
              new MapperConfiguration(config => config.CreateMap<User, UserBLL>().
          ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
          ForMember(dest => dest.Surname, opt => opt.MapFrom(c => c.Surname)).
          ForMember(dest => dest.Details, map => map.MapFrom(
              source => new DetailsBLL
              {
                  Age = source.Details.Age,
                  Adress = source.Details.Adress,
              })));

            return new Mapper(configMapper);
        }
    }
}
