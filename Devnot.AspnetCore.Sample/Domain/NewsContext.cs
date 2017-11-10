using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devnot.AspnetCore.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace Devnot.AspnetCore.Sample.Domain
{
    public class NewsContext : DbContext
    {

        public NewsContext(DbContextOptions<NewsContext> options):base(options)
        {
            
        }

        public DbSet<News> Newses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<News>().ToTable("News");
        }
    }
}
