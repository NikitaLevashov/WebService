using AutoMapper;
using System.Collections.Generic;
using WebService.BLL.ModelsBLL;
using WebService.DAL.Models;

namespace WebService.BLL.Mapping
{
    public static class MapperProfileUser
    {
        public static UserDAL MapToDALUser(this UserBLL userBL) => 
            MapperForDAL().Map<UserBLL, UserDAL>(userBL);
        public static UserBLL MapToBLLUser(this UserDAL userDAL) 
            => MapperForBLL().Map<UserDAL, UserBLL>(userDAL);
        public static IEnumerable<UserBLL> MapToEnumerableBLLUsers(this IEnumerable<UserDAL> usersDAL) 
            => MapperForBLL().Map<IEnumerable<UserDAL>, IEnumerable<UserBLL>>(usersDAL);

        public static IEnumerable<UserDAL> MapToEnumerableDALUsers(this IEnumerable<UserBLL> usersBLL) 
            => MapperForDAL().Map<IEnumerable<UserBLL>, IEnumerable<UserDAL>>(usersBLL);
        
        private static Mapper MapperForDAL()
        {
            var configMapper =
              new MapperConfiguration(config => config.CreateMap<UserBLL, UserDAL>().
          ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
          ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
          ForMember(dest => dest.Surname, opt => opt.MapFrom(c => c.Surname)).
          ForMember(dest => dest.Details, map => map.MapFrom(
              source => new DetailsDAL
              {
                  Id = source.Id,
                  Age = source.Details.Age,
                  Adress = source.Details.Adress,
              })));

            return new Mapper(configMapper);
        }

        private static Mapper MapperForBLL()
        {
            var configMapper =
              new MapperConfiguration(config => config.CreateMap<UserDAL, UserBLL>().
          ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
          ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
          ForMember(dest => dest.Surname, opt => opt.MapFrom(c => c.Surname)).
          ForMember(dest => dest.Details, map => map.MapFrom(
              source => new DetailsBLL
              {
                  Id = source.Details.Id,
                  Age = source.Details.Age,
                  Adress = source.Details.Adress,
              })));

            return new Mapper(configMapper);
        }
    }
}
