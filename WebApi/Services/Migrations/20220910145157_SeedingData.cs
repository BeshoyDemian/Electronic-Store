using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "TVs" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Laptops" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Sound Systems" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPercentage", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "50 inch Model 32A", 5, "https://images.philips.com/is/image/PhilipsConsumer/50PUT6604_56-IMS-en_SA?$jpglarge$&wid=960", "Samsung TV", 4500f },
                    { 2, 1, "49 inch Model 32A", 5, "https://www.lg.com/eg_en/images/tvs/32lk310/gallery/large01.jpg", "LG TV", 6000f },
                    { 3, 1, "32 inch Model 32A", 5, "https://www.lg.com/eg_en/images/tvs/md07527560/gallery/d-01.jpg", "LG TV", 3500f },
                    { 4, 2, "11th Generation Intel Core i7-1165G7 Processor (12MB Cache, up to 4.7 GHz) 512GB M.2 PCIe NVMe Solid State Drive  8GB, 8GBx1, DDR4, 2666MHz  15.6-inch FHD (1920 x 1080) Anti-glare LED Backlight Non-Touch Narrow Border WVA Display", 15, "https://m.media-amazon.com/images/I/71FST4IHj+L._AC_SX679_.jpg", "Dell Vostro 3510 Laptop 15.6 FHD", 16450f },
                    { 5, 2, " 15-EC1046NR AMD Ryzen 7 4800H -RAM 12GB -512 SDD- GTX1660 TI 6G - OS WIN10 -Display 15,6 Personal Computer", 10, "https://m.media-amazon.com/images/I/71mzCXW2j8L._AC_SX679_.jpg", "Hp Gaming Pavilion 15-EC1046NR", 19888f },
                    { 6, 3, "Party Speaker with Light Effects Full Panel - Black Unique and fashionable design.Country of Origin: China Made of is high quality Compatible with multiple devices and easy to use Unique and fashionable design. ", 20, "https://m.media-amazon.com/images/I/31ct5JPuy5S._AC_SY1000_.jpg", "JBL Partybox 1000 Bluetooth", 29400f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
