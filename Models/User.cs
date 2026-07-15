using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AttendanceMangSystemDBFirst.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string? Username { get; set; }

    [StringLength(100)]
    public string? Password { get; set; }

    [StringLength(20)]
    public string? Role { get; set; }
}
