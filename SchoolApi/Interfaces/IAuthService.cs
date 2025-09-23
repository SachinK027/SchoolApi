using SchoolApi.DTOs;
using SchoolApi.Models;

namespace SchoolApi.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> RegisterStudent(RegisterDto registerDto);
        Task<User> LoginAsync(LoginDto dto);
        string GenerateToken(User user, string JWT_Secret, int JWT_Validity_Mins);
        //Task LogoutAsync(int userId);
        //Task<bool> ValidateTokenAsync(string token);
    }
}
