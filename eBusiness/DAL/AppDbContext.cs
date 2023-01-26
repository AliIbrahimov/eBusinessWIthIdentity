using eBusiness.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBusiness.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
