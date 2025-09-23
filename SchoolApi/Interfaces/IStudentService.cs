using SchoolApi.DTOs;
using SchoolApi.Models;

namespace SchoolApi.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetStudentList();
        Task<StudentDto> GetStudentById(int id);
        Task<StudentDto> AddStudent(StudentDto studentDto);
        Task<bool> UpdateStudent(int studentId, StudentDto studentDto);
        Task<bool> DeleteStudent(int studentId);
    }
}
