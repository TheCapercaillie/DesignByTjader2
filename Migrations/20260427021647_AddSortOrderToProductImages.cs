using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignByTjader.Migrations
{
    /// <inheritdoc />
    public partial class AddSortOrderToProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProductImages");
        }
    }
}
