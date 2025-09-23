using System.ComponentModel.DataAnnotations;

namespace SchoolApi.DTOs
{
    public class StudentDto
    {

        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enrollment Date is required")]
        public DateTime EnrollmentDate { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
