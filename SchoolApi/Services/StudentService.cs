using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.DTOs;
using SchoolApi.Helpers;
using SchoolApi.Interfaces;
using SchoolApi.Models;

namespace SchoolApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _context;
        public StudentService(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDto>> GetStudentList()
        {
            var studentList = await _context.Students.Where(x => x.IsDeleted == false).ToListAsync();
            return studentList.Select(StudentMapper.MapToDto).ToList();
        }
        public async Task<StudentDto> GetStudentById(int studentId)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId && x.IsDeleted == false);
                if(student != null)
                {
                    return StudentMapper.MapToDto(student);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<StudentDto?> AddStudent(StudentDto dto)
        {
            try
            {
                var student = StudentMapper.ToEntity(dto);
                student.IsDeleted = false;

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return StudentMapper.MapToDto(student);
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public async Task<bool> UpdateStudent(int id, StudentDto dto)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                    return false;

                //student.Name = dto.Name;
                //student.Email = dto.Email;
                //student.EnrollmentDate = dto.EnrollmentDate;
                StudentMapper.UpdateEntity(student, dto);

                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                    return false;

                student.IsDeleted = true;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }
    }
}
