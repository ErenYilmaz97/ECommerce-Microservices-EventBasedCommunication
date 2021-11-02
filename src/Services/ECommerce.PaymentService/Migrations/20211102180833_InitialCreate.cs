using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.PaymentService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CardOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardSecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
