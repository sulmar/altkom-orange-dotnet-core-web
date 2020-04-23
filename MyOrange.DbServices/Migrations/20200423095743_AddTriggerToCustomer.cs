using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOrange.DbServices.Migrations
{
    public partial class AddTriggerToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("create trigger ...");

            //migrationBuilder.Sql("create procedure...");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.Sql("drop trigger ...");
        }
    }
}
