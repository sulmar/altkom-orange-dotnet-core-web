using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOrange.DbServices.Migrations
{
    public partial class AddSampleDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Author", "CreatedOn", "CustomerId", "Description", "DocumentType", "Size", "Title", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "Letitia Purdy", new DateTime(2019, 8, 27, 19, 46, 3, 152, DateTimeKind.Local).AddTicks(472), null, "Et ex rerum aut rerum doloremque dolore voluptatem.", "Pdf", 9899L, "granite.cif", new DateTime(2020, 4, 23, 5, 31, 2, 72, DateTimeKind.Local).AddTicks(2369) },
                    { 18, "Wyatt Watsica", new DateTime(2020, 2, 3, 22, 50, 32, 961, DateTimeKind.Local).AddTicks(5212), null, "Voluptatem placeat laudantium repellat.", "Excel", 937L, "action_items_face_to_face.fly", new DateTime(2020, 4, 23, 9, 15, 36, 959, DateTimeKind.Local).AddTicks(3335) },
                    { 17, "Lonzo Jones", new DateTime(2020, 1, 26, 20, 18, 28, 297, DateTimeKind.Local).AddTicks(8980), null, "Sapiente est enim consequatur consequatur autem temporibus.", "Pdf", 6477L, "burg_fantastic_concrete_bike.rmvb", new DateTime(2020, 4, 23, 1, 14, 46, 855, DateTimeKind.Local).AddTicks(4291) },
                    { 16, "Yvonne Kunde", new DateTime(2019, 7, 19, 12, 4, 55, 336, DateTimeKind.Local).AddTicks(8888), null, "Adipisci necessitatibus ab dicta vero blanditiis est nostrum.", "Word", 8822L, "manors_back_end_plastic.plf", new DateTime(2020, 4, 22, 13, 59, 32, 762, DateTimeKind.Local).AddTicks(1131) },
                    { 15, "Jolie Huels", new DateTime(2020, 3, 12, 21, 30, 48, 672, DateTimeKind.Local).AddTicks(1929), null, "Omnis aut soluta qui eum ipsam expedita dolores non eligendi.", "Excel", 9737L, "meadow.iota", new DateTime(2020, 4, 22, 23, 10, 34, 81, DateTimeKind.Local).AddTicks(6975) },
                    { 14, "Jany Abernathy", new DateTime(2019, 9, 26, 13, 56, 33, 86, DateTimeKind.Local).AddTicks(5839), null, "Laborum dolores quia soluta ut cupiditate ex dicta.", "Word", 2170L, "intelligent_granite_bacon.swi", new DateTime(2020, 4, 23, 8, 14, 9, 794, DateTimeKind.Local).AddTicks(6261) },
                    { 13, "Jovanny Borer", new DateTime(2019, 7, 16, 17, 59, 54, 903, DateTimeKind.Local).AddTicks(8878), null, "Cum corrupti esse.", "Excel", 6552L, "outdoors.acc", new DateTime(2020, 4, 23, 10, 50, 19, 210, DateTimeKind.Local).AddTicks(3826) },
                    { 12, "Tressie Reichel", new DateTime(2020, 2, 28, 13, 31, 36, 284, DateTimeKind.Local).AddTicks(2993), null, "Tempora animi autem dolor officia.", "Pdf", 3351L, "money_market_account.xpw", new DateTime(2020, 4, 22, 20, 32, 53, 454, DateTimeKind.Local).AddTicks(5524) },
                    { 11, "Jaylon O'Hara", new DateTime(2020, 4, 20, 0, 57, 22, 786, DateTimeKind.Local).AddTicks(7988), null, "Aut nobis qui ea veritatis excepturi.", "Pdf", 8897L, "lights_factors_cultivate.mods", new DateTime(2020, 4, 23, 3, 12, 45, 139, DateTimeKind.Local).AddTicks(7308) },
                    { 10, "Joyce Simonis", new DateTime(2020, 3, 18, 10, 41, 54, 389, DateTimeKind.Local).AddTicks(7872), null, "Atque qui eius odio temporibus quia ut aut voluptatem minima.", "Excel", 9501L, "orchestrate.sig", new DateTime(2020, 4, 23, 0, 25, 39, 618, DateTimeKind.Local).AddTicks(1683) },
                    { 9, "Deshawn Wuckert", new DateTime(2019, 8, 16, 17, 53, 37, 441, DateTimeKind.Local).AddTicks(6938), null, "Eos corporis officiis facilis velit odio provident nisi autem aut.", "Word", 3313L, "barbados_24_365_lead.mid", new DateTime(2020, 4, 22, 16, 32, 48, 96, DateTimeKind.Local).AddTicks(409) },
                    { 8, "Geoffrey Ritchie", new DateTime(2019, 7, 28, 0, 10, 47, 459, DateTimeKind.Local).AddTicks(7011), null, "Dolorem cumque enim at officiis.", "Word", 4774L, "facilitator.m4p", new DateTime(2020, 4, 22, 17, 5, 36, 202, DateTimeKind.Local).AddTicks(9356) },
                    { 7, "Fay Leuschke", new DateTime(2019, 8, 17, 14, 2, 49, 806, DateTimeKind.Local).AddTicks(9722), null, "Quidem labore doloremque similique et modi dolorum animi.", "Pdf", 1889L, "senior_concept_microchip.buffer", new DateTime(2020, 4, 23, 4, 46, 27, 194, DateTimeKind.Local).AddTicks(7485) },
                    { 6, "Bobbie Stamm", new DateTime(2019, 6, 26, 11, 41, 34, 794, DateTimeKind.Local).AddTicks(9351), null, "Ut est neque sit voluptatem magni architecto nostrum sed vitae.", "Word", 9267L, "rustic_fresh_chips_website_invoice.z5", new DateTime(2020, 4, 22, 12, 24, 6, 723, DateTimeKind.Local).AddTicks(1637) },
                    { 5, "Dexter Kessler", new DateTime(2020, 3, 29, 10, 49, 17, 672, DateTimeKind.Local).AddTicks(3567), null, "Ullam quia consequuntur quis voluptatum consequatur.", "Word", 5618L, "ssl.conf", new DateTime(2020, 4, 23, 8, 16, 49, 716, DateTimeKind.Local).AddTicks(7448) },
                    { 4, "Omari Borer", new DateTime(2019, 6, 22, 7, 38, 36, 755, DateTimeKind.Local).AddTicks(6527), null, "Rerum quia quos voluptatem veritatis totam ea iure quis.", "Pdf", 175L, "ville.rpss", new DateTime(2020, 4, 22, 15, 44, 51, 323, DateTimeKind.Local).AddTicks(1549) },
                    { 3, "Dakota Bradtke", new DateTime(2019, 6, 7, 23, 5, 11, 638, DateTimeKind.Local).AddTicks(4751), null, "Dicta aut corrupti rerum quae quia numquam dicta enim unde.", "CSV", 3134L, "bedfordshire_back_end_incredible_metal_shirt.fcdt", new DateTime(2020, 4, 22, 17, 11, 43, 16, DateTimeKind.Local).AddTicks(2345) },
                    { 2, "Hosea Padberg", new DateTime(2019, 8, 14, 13, 38, 29, 225, DateTimeKind.Local).AddTicks(2967), null, "Iste porro cumque perferendis doloribus aut vero veritatis sint cupiditate.", "CSV", 2801L, "security_fantastic_soft_mouse_virtual.bmp", new DateTime(2020, 4, 23, 3, 1, 26, 304, DateTimeKind.Local).AddTicks(1086) },
                    { 19, "Cordie Pollich", new DateTime(2020, 3, 20, 21, 30, 37, 860, DateTimeKind.Local).AddTicks(5527), null, "Voluptatum officia qui.", "CSV", 6857L, "buckinghamshire.gim", new DateTime(2020, 4, 22, 18, 14, 34, 567, DateTimeKind.Local).AddTicks(9668) },
                    { 20, "Sigrid Cronin", new DateTime(2020, 1, 14, 3, 30, 16, 902, DateTimeKind.Local).AddTicks(722), null, "Hic ipsam tempora rem.", "Excel", 2179L, "xss_orchestrator.tiff", new DateTime(2020, 4, 22, 14, 13, 51, 32, DateTimeKind.Local).AddTicks(4175) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
