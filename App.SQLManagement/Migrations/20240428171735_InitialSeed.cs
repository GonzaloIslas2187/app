using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.SQLManagement.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CardNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<int>(type: "int", nullable: false),
                    LastExtraction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FailedTries = table.Column<int>(type: "int", nullable: false),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CardNumber);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    CardNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UserCardNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK_Operations_Users_UserCardNumber",
                        column: x => x.UserCardNumber,
                        principalTable: "Users",
                        principalColumn: "CardNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UserCardNumber",
                table: "Operations",
                column: "UserCardNumber");

            Seed(migrationBuilder);
        }

        private void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "CardNumber", "Password", "Name", "AccountNumber", "CurrentBalance", "LastExtraction", "FailedTries", "IsLockedOut" },
                values: new object[,] {
                    {6420700080009000,"5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8","Gongo",314,100,DateTime.Now,0,false},
                    {6000700080009000,"5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8","Sol",698,100,DateTime.Now,0,false}
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "CardNumber", "Date", "Amount", "UserCardNumber" },
                values: new object[,] {
                    {6420700080009000,DateTime.Now,100,6420700080009000},
                    {6000700080009000,DateTime.Now,100,6000700080009000}
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
