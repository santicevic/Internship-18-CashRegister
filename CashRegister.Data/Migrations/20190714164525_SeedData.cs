using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CashRegisters",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ivana Ivanković" },
                    { 2, "Marko Marković" },
                    { 3, "Jure Jurić" },
                    { 4, "Marija Marić" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AmountInStock", "Barcode", "Name", "PriceWithTax", "Tax" },
                values: new object[,]
                {
                    { 15, 0, "4329482911", "IsoSport napitak", 7.99f, 25f },
                    { 14, 0, "4383292741", "Ožujsko pivo", 7.99f, 25f },
                    { 13, 0, "4399994211", "Heiniken pivo", 8.99f, 25f },
                    { 12, 0, "4382194211", "Bublica", 3.99f, 25f },
                    { 11, 0, "43119834211", "Tuna konzerva", 12.99f, 25f },
                    { 10, 0, "8822104211", "Panirani odrezak", 29.99f, 25f },
                    { 9, 0, "439912411", "Kiseli krastavci", 9.99f, 25f },
                    { 5, 0, "4383281055", "Vrečica mala", 0.59f, 25f },
                    { 7, 0, "8821230211", "Poli parizer", 6.99f, 25f },
                    { 6, 0, "4381172991", "Brod na napuhivanje", 123.99f, 25f },
                    { 16, 0, "4383299462", "Coca-cola", 6.99f, 25f },
                    { 4, 0, "4380284111", "Vrečica velika", 0.99f, 25f },
                    { 3, 0, "6201694211", "Choco loco", 10.99f, 25f },
                    { 2, 0, "4383520151", "Kruh didov", 6.99f, 25f },
                    { 1, 0, "4383294211", "Juha u vrečici", 12.99f, 25f },
                    { 8, 0, "4389928510", "Majoneza", 14.99f, 25f },
                    { 17, 0, "4383729131", "Čaše plastične", 29.99f, 25f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cashiers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cashiers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cashiers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cashiers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
