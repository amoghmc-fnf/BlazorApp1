using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEmployeeApi.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pic",
                table: "BlazorEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "BlazorEmployee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
