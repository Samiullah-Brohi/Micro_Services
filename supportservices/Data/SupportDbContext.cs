using Microsoft.EntityFrameworkCore;

namespace supportservices.Data;

public class SupportDbContext : DbContext
{
    public SupportDbContext(DbContextOptions<SupportDbContext> options)
        : base(options)
    {
    }
}