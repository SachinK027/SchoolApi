using SchoolApi.DTOs;
using SchoolApi.Models;

namespace SchoolApi.Helpers
{
    public static class UserMapper
    {
        public static UserDto MapUserToDto(User user, string token = null)
        {
            return new UserDto
            {
                UserId = user.UserId,
                Name = user.UserName,
                Email = user.Email,
                Token = token,
                Roles = user.UserRoles?.Select(ur => ur.Role.RoleName).ToList() ?? new List<string>()
            };
        }

        public static User MapRegisterDtoToUser(RegisterDto dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = EncryptionDecryption.GetEncrypt(dto.Password),
                IsDeleted = false
            };
        }

    }
}
