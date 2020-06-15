using BaseApiWithSwagger.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BaseApiWithSwagger.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Dummy> Dummies { get; set; }

        public void Seed()
        {
            if (!this.Dummies.Any())
            {
                this.Dummies.Add(
                    new Dummy
                    {
                        Id = Guid.NewGuid().ToString(),
                    }
                );

                this.SaveChanges();
            }
        }
    }
}
