using CRMHitssBack.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMHitssBack.Models.Context
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        }
    }
}
