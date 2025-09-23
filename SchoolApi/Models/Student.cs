using System;
using System.Collections.Generic;

namespace SchoolApi.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public bool? IsDeleted { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual User? User { get; set; }
}
