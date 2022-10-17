using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogBook.Data.Migrations
{
    public partial class MigrationDataBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteRecord = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YearIssue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteRecord = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "DeleteRecord", "Name" },
                values: new object[] { new Guid("23d04b00-2a00-4e5c-b7c8-0aa772d73b9a"), false, "Дж. Рихтер" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "DeleteRecord", "Name" },
                values: new object[] { new Guid("342e3c92-4bce-4037-839c-5ea6baed5804"), false, "М. Флеонов" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "DeleteRecord", "Name" },
                values: new object[] { new Guid("d73d3244-0c0e-4644-a0e9-4dd8c963ba8d"), false, "Р. Ривест" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorId", "Cover", "DeleteRecord", "Description", "ISBN", "Title", "YearIssue" },
                values: new object[,]
                {
                    { new Guid("243c40d5-7818-4c46-8069-fe0a43da149c"), new Guid("23d04b00-2a00-4e5c-b7c8-0aa772d73b9a"), null, false, "Программирование на платформе Microsof .Net Framework 4.5 на языке C#", "978-5-4461-1102-2", "CLR via C#", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("292ea292-cc97-4aef-ac27-f528e2801cb2"), new Guid("d73d3244-0c0e-4644-a0e9-4dd8c963ba8d"), null, false, "Книга представляет собой перевод учебника по курсу построения и анализа эффективных алгоритмов.", "5-900916-37-5", "Алгоритмы, посторение и анализ", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6fb2f2c6-5286-4a4d-b02a-f0340da405dc"), new Guid("342e3c92-4bce-4037-839c-5ea6baed5804"), null, false, "Хорошая книга для начинающих", "123-123-123", "Библия Delphi", new DateTime(2000, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b735e892-21a6-4a2f-b798-b53901bd6919"), new Guid("342e3c92-4bce-4037-839c-5ea6baed5804"), null, false, "Отличная книга по SQL даже сейчас!", "555-555-555", "Библия SQL", new DateTime(2000, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
