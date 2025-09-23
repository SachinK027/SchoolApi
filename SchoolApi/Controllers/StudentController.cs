using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.DTOs;
using SchoolApi.Interfaces;
using SchoolApi.Models;
using SchoolApi.Services;

namespace SchoolApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllStudent()
        {
            //var students = await _studentService.GetStudentList();
            //return Ok(students);
            try
            {
                var students = await _studentService.GetStudentList();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                    return NotFound($"Student with ID {id} not found.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdStudent = await _studentService.AddStudent(dto);

            if (createdStudent == null)
                return StatusCode(500, "An error occurred while creating the student.");

            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }

        [HttpPut("[Action]/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _studentService.UpdateStudent(id, dto);

            if (!updated)
                return NotFound($"Student with ID {id} not found or could not be updated.");

            return NoContent(); // 204 - success with no content
        }

        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudent(id);

            if (!deleted)
                return NotFound($"Student with ID {id} not found or already deleted.");

            return NoContent();
        }
    }
}
