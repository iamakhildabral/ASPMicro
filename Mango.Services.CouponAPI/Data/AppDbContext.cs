using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = 1,
                    CouponCode = "10FF",
                    DiscountAmount = 5,
                    MinAmount = 20,
                });
            
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = 2,
                    CouponCode="50JJ",
                    DiscountAmount = 6,
                    MinAmount = 10,
                });

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = 3,
                    CouponCode = "98HH",
                    DiscountAmount = 8,
                    MinAmount = 25,
                });

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId=4,
                    CouponCode="08TT",
                    DiscountAmount = 3,
                    MinAmount = 10,
                }
                );
        }

    }
}
