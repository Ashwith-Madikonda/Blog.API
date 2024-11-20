﻿using Blog.Application;
using Blog.Application.DTOs.Requests;
using Blog.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Gets users in the database by id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(BaseResponse.Ok(result));
        }


        [HttpPost]
        [SwaggerOperation(
           Summary = "Creates a new user")]
        public async Task<IActionResult> Post([FromBody] CreateUserRequestDto request, CancellationToken cancellationToken = default)
        {
            var result = await _userService.CreateUser(request, cancellationToken);
            return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
           Summary = "Updates existing user")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateUserRequestDto request, CancellationToken cancellationToken = default)
        {
            request.Id = id;
            var result = await _userService.UpdateUser(request, cancellationToken);
            return Ok(BaseResponse.Updated(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Deletes user")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _userService.DeleteUserById(id);
            return Ok(BaseResponse.Ok(result));
        }
    }
}
