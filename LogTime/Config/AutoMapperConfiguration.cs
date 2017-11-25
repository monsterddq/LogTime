using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.DTO;
using LogTime.Models;

namespace LogTime.Config
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<LogTime.Models.Task, TaskDTO>();
                cfg.CreateMap<Block, BlockDTO>();
            });
            //Mapper.Map<User, UserDTO>();
        }
    }
}
