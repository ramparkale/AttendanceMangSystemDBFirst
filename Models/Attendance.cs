using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AttendanceMangSystemDBFirst.Models;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    public int AttendanceId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckIn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckOut { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? WorkingHours { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Attendances")]
    public virtual Employee? Employee { get; set; }
}
