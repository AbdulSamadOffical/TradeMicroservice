﻿using AutoMapper;
using Trade.Domain.Dtos;
using Trade.Domain.Entities;
using Trade.Domain.Exceptions;
using Trade.Domain.RepositoryContracts;
using Trade.Infrastructure.Persistence;

namespace Trade.Infrastructure.Persistence.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IGenericRepository<User>  _baserepository;
        public UserRepository(IMapper mapper, ApplicationContext context, IGenericRepository<User> baserepository) 
        {
            _mapper = mapper;
            _context = context;
            _baserepository = baserepository;
        }

        public void CreateUser(User user)
        {
         
            _baserepository.Add(user);
        }

        public UserDto GetUserById(string userId)
        {
            var user = _baserepository.GetById(userId);
            if (user == null)
            {
                throw new NotFoundException("user no longer exists.");
            }
            var userDto = _mapper.Map<User, UserDto>(user);
            return userDto;

        }
    }
}
