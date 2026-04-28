using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClavierDOr.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePartieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScoreActuel",
                table: "Parties",
                newName: "ScoreAtteint");

            migrationBuilder.RenameColumn(
                name: "JoueurId",
                table: "Parties",
                newName: "PouvoirDejaUtilise");

            migrationBuilder.AddColumn<int>(
                name: "IndexQuestion",
                table: "Parties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pseudo",
                table: "Parties",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleChoisi",
                table: "Parties",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexQuestion",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "Pseudo",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "RoleChoisi",
                table: "Parties");

            migrationBuilder.RenameColumn(
                name: "ScoreAtteint",
                table: "Parties",
                newName: "ScoreActuel");

            migrationBuilder.RenameColumn(
                name: "PouvoirDejaUtilise",
                table: "Parties",
                newName: "JoueurId");
        }
    }
}
