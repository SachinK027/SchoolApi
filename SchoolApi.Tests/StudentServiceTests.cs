using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Tests
{
    public class StudentServiceTests
    {
        private SchoolDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSchoolDb")
                .Options;

            var context = new SchoolDbContext(options);

            // Seed one student for test
            context.Students.Add(new Student
            {
                StudentId = 1,
                Name = "Test Student",
                Email = "test@student.com",
                IsDeleted = false
            });
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetStudentById_ShouldReturnStudent_WhenStudentExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new StudentService(context);

            // Act
            var studentDto = await service.GetStudentById(1);

            // Assert
            Assert.NotNull(studentDto);
            Assert.Equal(1, studentDto.StudentId);
            Assert.Equal("Test Student", studentDto.Name);
        }
    }
}
