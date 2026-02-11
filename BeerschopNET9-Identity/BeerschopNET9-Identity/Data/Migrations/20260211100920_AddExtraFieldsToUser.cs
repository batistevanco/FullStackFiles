using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerschopNET9_Identity.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");
        }
    }
}
