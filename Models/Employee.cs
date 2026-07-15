using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AttendanceMangSystemDBFirst.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(100)]
    public string? EmployeeName { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Mobile { get; set; }

    public int? DepartmentId { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department? Department { get; set; }
}
