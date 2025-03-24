using Microsoft.EntityFrameworkCore;
using TravelBuddy_Web.Models;

namespace TravelBuddy_Web.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }


}
