using AutoMapper;
using CRUDApplication.Data;
using CRUDApplication.Domain.Entities;
using CRUDApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUDApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _context;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public AuthController(IAuthenticationRepository context, IMapper mapper,IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto entity)
        {
            // Hash the password (use a proper hashing algorithm in production)
            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            var mapped_entity = _mapper.Map<User>(entity);
            await _context.Add(mapped_entity);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto entity)
        {
            var mapped_entity = _mapper.Map<User>(entity);
            var user = await _context.Get(mapped_entity);
            if (user == null || !BCrypt.Net.BCrypt.Verify(entity.Password, user.Password))
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            claims.AddRange(user.GetRoles().Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }
    }
}
