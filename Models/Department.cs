using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AttendanceMangSystemDBFirst.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [StringLength(100)]
    public string? DepartmentName { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
