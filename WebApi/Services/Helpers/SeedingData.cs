using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Models;

namespace Services.Helpers
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id = 1, Name = "TVs" },
                    new Category() { Id = 2, Name = "Laptops" },
                    new Category() { Id = 3, Name = "Sound Systems" }
                    );
            modelBuilder.Entity<Product>().HasData(
         new Product() { Id = 1, Name = "Samsung TV", Description = "50 inch Model 32A", DiscountPercentage = 5, CategoryId = 1, Price = 4500, ImageUrl = "https://images.philips.com/is/image/PhilipsConsumer/50PUT6604_56-IMS-en_SA?$jpglarge$&wid=960" },
         new Product() { Id = 2, Name = "LG TV", Description = "49 inch Model 32A", DiscountPercentage = 5, CategoryId = 1, Price = 6000, ImageUrl = "https://www.lg.com/eg_en/images/tvs/32lk310/gallery/large01.jpg" },
         new Product() { Id = 3, Name = "LG TV", Description = "32 inch Model 32A", DiscountPercentage = 5, CategoryId = 1, Price = 3500, ImageUrl = "https://www.lg.com/eg_en/images/tvs/md07527560/gallery/d-01.jpg" },
         new Product() { Id = 4, Name = "Dell Vostro 3510 Laptop 15.6 FHD", Description = "11th Generation Intel Core i7-1165G7 Processor (12MB Cache, up to 4.7 GHz) 512GB M.2 PCIe NVMe Solid State Drive  8GB, 8GBx1, DDR4, 2666MHz  15.6-inch FHD (1920 x 1080) Anti-glare LED Backlight Non-Touch Narrow Border WVA Display", DiscountPercentage = 15, CategoryId = 2, Price = 16450, ImageUrl = "https://m.media-amazon.com/images/I/71FST4IHj+L._AC_SX679_.jpg" },
         new Product() { Id = 5, Name = "Hp Gaming Pavilion 15-EC1046NR", Description = " 15-EC1046NR AMD Ryzen 7 4800H -RAM 12GB -512 SDD- GTX1660 TI 6G - OS WIN10 -Display 15,6 Personal Computer", DiscountPercentage = 10, CategoryId = 2, Price = 19888, ImageUrl = "https://m.media-amazon.com/images/I/71mzCXW2j8L._AC_SX679_.jpg" },
         new Product() { Id = 6, Name = "JBL Partybox 1000 Bluetooth", Description = "Party Speaker with Light Effects Full Panel - Black Unique and fashionable design.Country of Origin: China Made of is high quality Compatible with multiple devices and easy to use Unique and fashionable design. ", DiscountPercentage = 20, CategoryId = 3, Price = 29400, ImageUrl = "https://m.media-amazon.com/images/I/31ct5JPuy5S._AC_SY1000_.jpg" }
        );
        }
    }
}
