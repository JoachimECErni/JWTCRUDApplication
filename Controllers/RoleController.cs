using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDApplication.Data;
using CRUDApplication.Domain.Entities;
using AutoMapper;
using CRUDApplication.Domain.Contracts;
using CRUDApplication.Common;
using CRUDApplication.Repositories.Interfaces;
using System.Data;

namespace CRUDApplication.Controllers
{
    [ApiController]
    [Route("api/")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _context;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("role")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _context.GetAll();
                var rolesDto = _mapper.Map<List<RoleDto>>(roles);
                return Ok(rolesDto);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                var roles = await _context.Get(id);
                var rolesDto = _mapper.Map<RoleDto>(roles);
                return Ok(rolesDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRole createrole)
        {
            try
            {
                var role = _mapper.Map<Role>(createrole);
                var createdRole = await _context.Add(role);
                var roleDTO = _mapper.Map<RoleDto>(createdRole);
                return CreatedAtAction(nameof(GetRole),new { id = roleDTO.Id}, roleDTO);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured: ");
            }
        }

        [HttpPut("role")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRole updateRole)
        {
            try
            {
                var role = await _context.Get(id);
                if (role == null)
                    return NotFound();
                _mapper.Map(updateRole, role);
                var updatedRole = await _context.Update(role);
                var roleDto = _mapper.Map<RoleDto>(updatedRole);
                return Ok(roleDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpDelete("role")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _context.Delete(id);
                if (role == null)
                    return NotFound();
                var roleDto = _mapper.Map<RoleDto>(role);
                return Ok(roleDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }
    }
}
