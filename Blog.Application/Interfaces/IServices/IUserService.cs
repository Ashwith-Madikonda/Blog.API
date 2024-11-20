using Blog.Application.DTOs.Requests;
using Blog.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUserById(Guid id);
        Task<UserResponseDto> CreateUser(CreateUserRequestDto request, CancellationToken cancellationToken = default);
        Task<UserResponseDto> UpdateUser(UpdateUserRequestDto request, CancellationToken cancellationToken = default);
        Task<UserResponseDto> DeleteUserById(Guid id);
    }
}
