using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CRUDApplication.Domain.Entities;
using CRUDApplication.Domain.Contracts;
using CRUDApplication.Repositories.Interfaces;
using CRUDApplication.Common.Exceptions;

namespace CRUDApplication.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleRepository _context;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("userroles")]
        public async Task<IActionResult> GetUserRoles()
        {
            try
            {
                var userRoles = await _context.GetAll();
                var userRolesDto = _mapper.Map<List<UserRoleDto>>(userRoles);
                return Ok(userRolesDto);
            }
            catch (Exception e)
            {
                var errorMessage = ExceptionMessage.GetMessage(e);
                return StatusCode(500, errorMessage);
            }
        }

        [HttpGet("userroles/{id}")]
        public async Task<IActionResult> GetUserRole(int id)
        {
            try
            {
                var userRole = await _context.Get(id);
                if (userRole == null)
                    return NotFound();
                var userRoleDto = _mapper.Map<UserRoleDto>(userRole);
                return Ok(userRoleDto);
            }
            catch (Exception e)
            {
                var errorMessage = ExceptionMessage.GetMessage(e);
                return StatusCode(500, errorMessage);
            }
        }

        [HttpPost("userroles")]
        [TryCatch]
        public async Task<IActionResult> CreateUserRole([FromBody] CreateUserRole createUserRole)
        {
            //try
            //{
                var userRole = _mapper.Map<UserRole>(createUserRole);
                var createdUserRole = await _context.Add(userRole);
                var userRoleDto = _mapper.Map<UserRoleDto>(createdUserRole);
                return CreatedAtAction(nameof(GetUserRole), new { id = userRoleDto.UserId }, userRoleDto);
            //}
            //catch (Exception e)
            //{
                //var errorMessage = ExceptionMessage.GetMessage(e);
                //return StatusCode(500, errorMessage);
            //}
        }

        [HttpPut("userroles/{id}")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] UpdateUserRole updateUserRole)
        {
            try
            {
                var userRole = await _context.Get(id);
                if (userRole == null)
                    return NotFound();
                _mapper.Map(updateUserRole, userRole);
                var updatedUserRole = await _context.Update(userRole);
                var userRoleDto = _mapper.Map<UserRoleDto>(updatedUserRole);
                return Ok(userRoleDto);
            }
            catch (Exception e)
            {
                var errorMessage = ExceptionMessage.GetMessage(e);
                return StatusCode(500, errorMessage);
            }
        }

        [HttpDelete("userroles/{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            try
            {
                var userRole = await _context.Delete(id);
                if (userRole == null)
                    return NotFound();
                var userRoleDto = _mapper.Map<UserRoleDto>(userRole);
                return Ok(userRoleDto);
            }
            catch (Exception e)
            {
                var errorMessage = ExceptionMessage.GetMessage(e);
                return StatusCode(500, errorMessage);
            }
        }
    }
}