using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public StudentAdoController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetStudentList()
        {
            var studentList = new List<Student>();
            var connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT StudentId, Name, Email, EnrollmentDate FROM Students WHERE IsDeleted = 0", conn);
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read()) 
                {
                    studentList.Add(new Student
                    {
                        StudentId = (int)reader["StudentId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        EnrollmentDate = (DateTime)reader["EnrollmentDate"]
                    });
                }
            }
            return Ok(studentList);

        }
    }
}
