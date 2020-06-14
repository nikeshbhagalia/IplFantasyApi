using BaseApiWithSwagger.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseApiWithSwagger.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Dummy> Dummy { get; set; }
    }
}
