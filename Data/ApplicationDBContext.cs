using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using stock_market_api.models;

namespace stock_market_api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x =>
            {
                x.HasKey(p => new { p.AppUserId, p.StockId });
            });

            builder.Entity<Portfolio>()
                .HasOne(p => p.AppUser)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(p => p.Stock)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{ Id = "Admin", Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole{ Id = "User", Name = "User", NormalizedName = "USER"}
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}