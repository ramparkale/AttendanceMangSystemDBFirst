using AttendanceMangSystemDBFirst.Data;
using Microsoft.EntityFrameworkCore;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Login(LoginModel model)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x =>
                x.Username == model.Username &&
                x.Password == model.Password);

        return user != null;
    }
}