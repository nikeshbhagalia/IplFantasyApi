using Base.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Base.Api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Dummy> Dummies { get; set; }
    }
}
