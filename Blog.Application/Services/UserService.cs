using Blog.Application.DTOs.Requests;
using Blog.Application.DTOs.Responses;
using Blog.Application.Exceptions;
using Blog.Application.Interfaces.Repositories;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.Interfaces.IServices;
using AutoMapper.QueryableExtensions;


namespace Blog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IBaseRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            var dto = _mapper.Map<UserResponseDto>(user);
            return dto;
        }

        public async Task<UserResponseDto> CreateUser(CreateUserRequestDto request, CancellationToken cancellationToken = default)
        {
            bool userExists = _userRepository.Query().Any(x => x.Name == request.UserName);
            if (userExists) throw new BadRequestException($"El nombre de usuario: {request.UserName} ya existe");

            var userEntity = _mapper.Map<UserEntity>(request);
            var user = await _userRepository.AddAsync(userEntity, cancellationToken);
            var dto = _mapper.Map<UserResponseDto>(user);

            return dto;
        }

        public async Task<UserResponseDto> UpdateUser(UpdateUserRequestDto request, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<UserEntity>(request);
            var result = await _userRepository.UpdateAsync(user);

            var dto = _mapper.Map<UserResponseDto>(result);
            return dto;
        }

        public async Task<UserResponseDto> DeleteUserById(Guid id)
        {
            var result = await _userRepository.Delete(id);

            var dto = _mapper.Map<UserResponseDto>(result);

            return dto;
        }
    }
}
