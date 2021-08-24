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
        public static UserDAL MapToDALUser(this UserBLL userBL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<UserBLL, UserDAL>());
            var mapper = new Mapper(configMapper);

            var userDAL = mapper.Map<UserBLL, UserDAL>(userBL);

            return userDAL;
        }

        public static UserBLL MapToBLLUser(this UserDAL userDAL)
        {
            var configMapper = new MapperConfiguration(config => config.CreateMap<UserDAL, UserBLL>());
            var mapper = new Mapper(configMapper);

            var userBLL = mapper.Map<UserDAL, UserBLL>(userDAL);

            return userBLL;
        }

        public static IEnumerable<UserBLL> MapToEnumerableBLLUsers(this IEnumerable<UserDAL> usersDAL)
        {
            var configMapper = new MapperConfiguration(config =>config.CreateMap<UserDAL, UserBLL>().
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

            var mapper = new Mapper(configMapper);

            var usersBLL = mapper.Map<IEnumerable<UserDAL>, IEnumerable<UserBLL>>(usersDAL);

            return usersBLL;
        }

        public static IEnumerable<UserDAL> MapToEnumerableDALUsers(this IEnumerable<UserBLL> usersBLL)
        {
            var configMapper =
               new MapperConfiguration(config => config.CreateMap<UserBLL, UserDAL>().
           ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
           ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
           ForMember(dest => dest.Surname, opt => opt.MapFrom(c => c.Surname)).
           ForMember(dest => dest.Details, map => map.MapFrom(
               source => new DetailsDAL
               {
                   Id = source.Details.Id,
                   Age = source.Details.Age,
                   Adress = source.Details.Adress,
               })));

            var mapper = new Mapper(configMapper);

            var usersDAL = mapper.Map<IEnumerable<UserBLL>, IEnumerable<UserDAL>>(usersBLL);

            return usersDAL;
        }       
    }
}
