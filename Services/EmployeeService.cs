using AttendanceMangSystemDBFirst.Data;
using AttendanceMangSystemDBFirst.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _context.Employees
            .Include(x => x.Department)
            .ToListAsync();
    }

    public async Task AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployee(int id)
    {
        var emp = await _context.Employees.FindAsync(id);

        if (emp != null)
        {
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }
    }
}