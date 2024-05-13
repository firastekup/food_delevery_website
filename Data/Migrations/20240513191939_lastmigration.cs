using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_delevery_google_auth_Final_V.Data.Migrations
{
    /// <inheritdoc />
    public partial class lastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "commandef",
                columns: table => new
                {
                    IdCommande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telclient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomlivreur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    food = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandef", x => x.IdCommande);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commandef");
        }
    }
}
