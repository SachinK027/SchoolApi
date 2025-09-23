using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SchoolApi.Data;
using SchoolApi.DTOs;
using SchoolApi.Helpers;
using SchoolApi.Interfaces;
using SchoolApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly SchoolDbContext _DbContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        public AuthService(SchoolDbContext DbContext, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _DbContext = DbContext;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<UserDto> RegisterStudent(RegisterDto registerDto)
        {
            //check if user already logged in or not
            var existingUser = await _DbContext.Users.AnyAsync(u => u.Email == registerDto.Email && u.IsDeleted == false);
            if (existingUser)
            {
                throw new Exception("User already exists with this email");
            }

            var user = UserMapper.MapRegisterDtoToUser(registerDto);

            _DbContext.Users.Add(user);
            await _DbContext.SaveChangesAsync();

            var roleName = registerDto.RoleName ?? "Student";
            var role = await _DbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                throw new Exception($"Role '{roleName}' does not exist");
            }
            var userRole = new UserRole
            {
                UserId = user.UserId,
                RoleId = role.RoleId
            };
            _DbContext.UserRoles.Add(userRole);
            await _DbContext.SaveChangesAsync();
            switch (roleName.ToLower())
            {
                case "student":
                    var student = new Student
                    {
                        Name = registerDto.Name,
                        Email = registerDto.Email,
                        EnrollmentDate = DateTime.UtcNow,
                        UserId = user.UserId,
                        IsDeleted = false
                    };
                    _DbContext.Students.Add(student);
                    break;

                //case "teacher":
                //    var teacher = new Teacher
                //    {
                //        Name = registerDto.Name,
                //        Email = registerDto.Email,
                //        HireDate = DateTime.UtcNow,
                //        UserId = user.UserId,
                //        IsDeleted = false
                //    };
                //    _DbContext.Teachers.Add(teacher);
                //    break;

                    // case "admin": maybe no separate domain table, just role assignment.
            }

            await _DbContext.SaveChangesAsync();
            user.UserRoles = new List<UserRole> { userRole };

            return UserMapper.MapUserToDto(user);
        }
        public async Task<User> LoginAsync(LoginDto dto)
        {
            var user = await _DbContext.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email && u.PasswordHash == EncryptionDecryption.GetEncrypt(dto.Password) && u.IsDeleted == false);
            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }
            // Generate JWT token
            //var token = JwtTokenGenerator.GenerateJwtToken(user, _configuration);
            return user;
        }
        public string GenerateToken(User user, string JWT_Secret, int JWT_Validity_Mins)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JWT_Secret);

            var roles = _DbContext.UserRoles
                           .Where(ur => ur.UserId == user.UserId && !ur.IsDeleted)
                           .Select(ur => ur.Role.RoleName)
                           .ToList();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("_LoginId", user.UserId.ToString()),
                    new Claim("_UserName", user.UserName ?? string.Empty),
                    new Claim("Email", user.Email ?? string.Empty),
                    new Claim("Roles", JsonConvert.SerializeObject(roles))
                }),
                Expires = DateTime.UtcNow.AddMinutes(JWT_Validity_Mins),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
