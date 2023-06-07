using Microsoft.EntityFrameworkCore;
using VBInterfacing.Models;

namespace VBInterfacing.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL2021;Database=VBInterfacingDb;Trusted_Connection=True;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
