﻿using LogTime.DTO;
using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.Repository;
using LogTime.Utility;
using AutoMapper;

namespace LogTime.Services
{
    public class UserService : AbstractService<UserDTO, string, User>
    {
        private readonly ICommonRepository<User> repository;
        public UserService() : base()
        {
            repository = new UserRepository();
            paginator = new Paginator<UserDTO, User>();
        }

        public override UserDTO Add(UserDTO obj)
        {
            try
            {
                repository.AddNew(Mapper.Map<User>(obj));
                return obj;
            }
            catch (Exception)
            {
                throw new Exception("Can't create User");
            }
        }

        public override UserDTO Delete(String key)
        {
            UserDTO user = FetchByKey(key);
            if (user != null)
            {
                repository.Remove(Mapper.Map<User>(user));
                return user;
            }
            else
                throw new Exception("Can't find user by key.");
        }

        public override UserDTO Edit(UserDTO obj)
        {
            User user = repository.Find(obj.user_id);
            if (user != null)
            {
                repository.Modify(Mapper.Map<User>(obj));
                return obj;
            }
            else
                throw new Exception("Can't update user");
        }

        public override UserDTO FetchByKey(string key)
        {
            User user = repository.Find(key);
            return user == null ? null : Mapper.Map<UserDTO>(user);

        }

        public override Pager<UserDTO> LoadAll(int CurrentPage, int NoOfRowInPage)
        {
            return null;
        }
    }
}