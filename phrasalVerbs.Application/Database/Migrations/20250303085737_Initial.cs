using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhrasalVerbs.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhrasalVerbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Verb = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhrasalVerbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhrasalVerbId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verb = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_PhrasalVerbs_PhrasalVerbId",
                        column: x => x.PhrasalVerbId,
                        principalTable: "PhrasalVerbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhrasalVerbs",
                columns: new[] { "Id", "Verb" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Abide by" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Account for" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Ache for" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Act on" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Act out" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Act up" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Act upon" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Add on" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Add up" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "Add up to" },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "Advise against" },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "Agree with" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "Aim at" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "Allow for" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), "Angle for" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Answer back" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Answer for" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Argue down" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Argue out" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Ask about" }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Language", "PhrasalVerbId", "Verb" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "pl", new Guid("00000000-0000-0000-0000-000000000001"), "Zaakceptować lub postępować zgodnie z decyzją lub zasadą" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "pl", new Guid("00000000-0000-0000-0000-000000000002"), "Wyjaśnić" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "pl", new Guid("00000000-0000-0000-0000-000000000003"), "Bardzo czegoś lub kogoś chcieć" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "pl", new Guid("00000000-0000-0000-0000-000000000004"), "Podjąć działania na podstawie otrzymanych informacji" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "pl", new Guid("00000000-0000-0000-0000-000000000005"), "Odtworzyć coś za pomocą gestów" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "pl", new Guid("00000000-0000-0000-0000-000000000006"), "Zachowywać się źle lub dziwnie" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "pl", new Guid("00000000-0000-0000-0000-000000000007"), "Podjąć działania na podstawie otrzymanych informacji" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "pl", new Guid("00000000-0000-0000-0000-000000000008"), "Dodać do obliczeń" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "pl", new Guid("00000000-0000-0000-0000-000000000009"), "Dokonać matematycznego podsumowania" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "pl", new Guid("00000000-0000-0000-0000-00000000000a"), "Doprowadzić do" },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "pl", new Guid("00000000-0000-0000-0000-00000000000b"), "Odradzać" },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "pl", new Guid("00000000-0000-0000-0000-00000000000c"), "Zgadzać się z" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "pl", new Guid("00000000-0000-0000-0000-00000000000d"), "Celować w" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "pl", new Guid("00000000-0000-0000-0000-00000000000e"), "Uwzględniać" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), "pl", new Guid("00000000-0000-0000-0000-00000000000f"), "Zabiegać o coś" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "pl", new Guid("00000000-0000-0000-0000-000000000010"), "Odpyskować" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "pl", new Guid("00000000-0000-0000-0000-000000000011"), "Odpowiadać za" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "pl", new Guid("00000000-0000-0000-0000-000000000012"), "Przekonać kogoś do zmiany zdania" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "pl", new Guid("00000000-0000-0000-0000-000000000013"), "Przedyskutować coś do końca" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "pl", new Guid("00000000-0000-0000-0000-000000000014"), "Pytać o" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_PhrasalVerbId",
                table: "Translations",
                column: "PhrasalVerbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "PhrasalVerbs");
        }
    }
}
