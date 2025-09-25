using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDapperController : ControllerBase
    {
        private readonly IConfiguration _config;
        public StudentDapperController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetStudentList()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(connectionString))
            {
                var studentList = await connection.QueryAsync<Student>("SELECT StudentId, Name, Email, EnrollmentDate FROM Students WHERE IsDeleted = 0");
                return Ok(studentList);
            }
        }
    }
}
