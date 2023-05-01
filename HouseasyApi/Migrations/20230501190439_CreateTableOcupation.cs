using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseasyApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableOcupation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_Idadress",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Contact_Idcontact",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Idoccupation",
                table: "Users",
                newName: "IdOccupation");

            migrationBuilder.RenameColumn(
                name: "Idcontact",
                table: "Users",
                newName: "IdContact");

            migrationBuilder.RenameColumn(
                name: "Idadress",
                table: "Users",
                newName: "IdAdress");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Idcontact",
                table: "Users",
                newName: "IX_Users_IdContact");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Idadress",
                table: "Users",
                newName: "IX_Users_IdAdress");

            migrationBuilder.CreateTable(
                name: "Ocupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdOccupation",
                table: "Users",
                column: "IdOccupation");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_IdAdress",
                table: "Users",
                column: "IdAdress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Contact_IdContact",
                table: "Users",
                column: "IdContact",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ocupation_IdOccupation",
                table: "Users",
                column: "IdOccupation",
                principalTable: "Ocupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_IdAdress",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Contact_IdContact",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ocupation_IdOccupation",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Ocupation");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdOccupation",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdOccupation",
                table: "Users",
                newName: "Idoccupation");

            migrationBuilder.RenameColumn(
                name: "IdContact",
                table: "Users",
                newName: "Idcontact");

            migrationBuilder.RenameColumn(
                name: "IdAdress",
                table: "Users",
                newName: "Idadress");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdContact",
                table: "Users",
                newName: "IX_Users_Idcontact");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdAdress",
                table: "Users",
                newName: "IX_Users_Idadress");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_Idadress",
                table: "Users",
                column: "Idadress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Contact_Idcontact",
                table: "Users",
                column: "Idcontact",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
