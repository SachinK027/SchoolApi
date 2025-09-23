namespace SchoolApi.DTOs
{
    public class UserDto
    {
        //public string Token { get; set; } = string.Empty;
        //public DateTime Expires { get; set; }
        //public int UserId { get; set; }
        //public string Email { get; set; } = string.Empty;
        //public IEnumerable<string> Roles { get; set; } = Enumerable.Empty<string>();
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
