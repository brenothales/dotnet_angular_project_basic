using DatingApp.API.model;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){ }

        public DbSet<Value> Values { get; set; }
        public DbSet<Use> Users { get; set; }
    }
}