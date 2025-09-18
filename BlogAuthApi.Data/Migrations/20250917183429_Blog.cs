using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAuthApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Blog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_EmployeeId",
                table: "Blogs",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Employees_EmployeeId",
                table: "Blogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Employees_EmployeeId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_EmployeeId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Blogs");
        }
    }
}
