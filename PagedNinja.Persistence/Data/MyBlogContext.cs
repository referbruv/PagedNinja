using Microsoft.EntityFrameworkCore;
using PagedNinja.Core.Data.Entities;

namespace PagedNinja.Persistence.Data
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
