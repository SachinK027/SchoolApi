using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SchoolApi.Data;
using SchoolApi.DTOs;
using SchoolApi.Helpers;
using SchoolApi.Interfaces;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtSettings _jwtSetting;
        private readonly SchoolDbContext _dbContext;
        public AuthController(IAuthService authService, IOptions<JwtSettings> jwtOptions, SchoolDbContext schoolDbContext)
        {
            _authService = authService;
            _jwtSetting = jwtOptions.Value;
            _dbContext = schoolDbContext;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var user = await _authService.RegisterStudent(registerDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var user = await _authService.LoginAsync(dto);
                if(user.UserId != 0)
                {
                    var token = _authService.GenerateToken(user, _jwtSetting.Key, _jwtSetting.DurationInMinutes);
                    user.JwtToken = token;
                    user.JwtExpiry = DateTime.UtcNow.AddMinutes(_jwtSetting.DurationInMinutes);
                    await _dbContext.SaveChangesAsync();
                    return Ok(UserMapper.MapUserToDto(user, token));
                }
                else
                {
                    return Unauthorized("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
