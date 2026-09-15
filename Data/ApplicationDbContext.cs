using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stockastic.Domain.Entities;
namespace Stockastic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        //Entities
        public DbSet<User> Users { get; set; }
        
    }
}
