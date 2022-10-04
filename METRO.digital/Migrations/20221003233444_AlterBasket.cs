using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace METRO.digital.Migrations
{
    /// <inheritdoc />
    public partial class AlterBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtIcle_Baskets_BasketId",
                table: "ArtIcle");

            migrationBuilder.DropColumn(
                name: "TotalGross",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "TotalNet",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "PaysVAT",
                table: "Baskets",
                newName: "PaysVat");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ArtIcle",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "BasketId",
                table: "ArtIcle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtIcle_Baskets_BasketId",
                table: "ArtIcle",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtIcle_Baskets_BasketId",
                table: "ArtIcle");

            migrationBuilder.RenameColumn(
                name: "PaysVat",
                table: "Baskets",
                newName: "PaysVAT");

            migrationBuilder.AddColumn<long>(
                name: "TotalGross",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TotalNet",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "ArtIcle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<long>(
                name: "BasketId",
                table: "ArtIcle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtIcle_Baskets_BasketId",
                table: "ArtIcle",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
