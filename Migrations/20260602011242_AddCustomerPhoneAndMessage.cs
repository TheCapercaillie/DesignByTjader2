using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignByTjader.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerPhoneAndMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Orders");
        }
    }
}
