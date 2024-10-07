using Microsoft.EntityFrameworkCore;

namespace memTodayApi.Models;

public class memTodayContext : DbContext 
{
    public memTodayContext (DbContextOptions<memTodayContext> options) : base(options)
    {

    }

    public DbSet<memTodayItem> memTodayItems {get; set;} = null!;
}