using SchoolApi.DTOs;
using SchoolApi.Models;

namespace SchoolApi.Helpers
{
    public static class StudentMapper
    {
        public static StudentDto MapToDto(Student student)
        {
            return new StudentDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                EnrollmentDate = student.EnrollmentDate
                //IsDeleted = student.IsDeleted ?? false
            };
        }
        public static Student ToEntity(StudentDto dto)
        {
            return new Student
            {
                StudentId = dto.StudentId,
                Name = dto.Name,
                Email = dto.Email,
                EnrollmentDate = dto.EnrollmentDate,
                IsDeleted = false
            };
        }
        public static void UpdateEntity(Student student, StudentDto studentDto)
        {
            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.EnrollmentDate = studentDto.EnrollmentDate;
        }
    }
}
