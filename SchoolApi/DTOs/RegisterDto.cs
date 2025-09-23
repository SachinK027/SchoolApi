namespace SchoolApi.DTOs
{
    public class RegisterDto
    {
        //public int? UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string RoleName { get; set; } = "Student";
    }
}
