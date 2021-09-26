using URL_Shortener.Models;
using Microsoft.EntityFrameworkCore;

namespace URL_Shortener.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        public DbSet<URLs> URL { get; set; }
    }
}
