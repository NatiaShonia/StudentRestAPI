using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentRestAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Akash@simlilearn.com", "Akash", 0, "Gupta", "Images/Akash.png" },
                    { 2, new DateTime(1990, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sam@simlilearn.com", "Sam", 0, "Matheus", "Images/Sam.png" },
                    { 3, new DateTime(1987, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Chris@simlilearn.com", "Christina", 1, "Frost", "Images/Christina.png" },
                    { 4, new DateTime(1993, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rachel@simlilearn.com", "Rachel", 1, "Stone", "Images/Rachel.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
