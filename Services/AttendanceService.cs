using AttendanceMangSystemDBFirst.Data;
using AttendanceMangSystemDBFirst.Models;
using Microsoft.EntityFrameworkCore;
public class AttendanceService
{
    private readonly AppDbContext _context;

    public AttendanceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CheckIn(int employeeId)
    {
        Attendance attendance = new()
        {
            EmployeeId = employeeId,
            AttendanceDate = DateOnly.FromDateTime(DateTime.Now),
            CheckIn = DateTime.Now,
            Status = "Present"
        };

        _context.Attendances.Add(attendance);

        await _context.SaveChangesAsync();
    }

    public async Task CheckOut(int employeeId)
    {
        var attendance = await _context.Attendances
            .Where(x => x.EmployeeId == employeeId &&
                        x.AttendanceDate == DateOnly.FromDateTime(DateTime.Now))
            .FirstOrDefaultAsync();

        if (attendance != null)
        {
            attendance.CheckOut = DateTime.Now;

            attendance.WorkingHours =
            (decimal)(attendance.CheckOut.Value - attendance.CheckIn.Value).TotalHours;

            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Attendance>> GetHistory(int employeeId)
    {
        return await _context.Attendances
            .Where(x => x.EmployeeId == employeeId)
            .OrderByDescending(x => x.AttendanceDate)
            .ToListAsync();
    }
}