using Microsoft.EntityFrameworkCore;

namespace Mvc.Net_Sample.Models
{
    public class TrilasDbContext : DbContext
    {
        public TrilasDbContext(DbContextOptions<TrilasDbContext> options) : base(options)
        {
        }
        public DbSet<Trial> MVC_Trials { get; set; }

    }
}
