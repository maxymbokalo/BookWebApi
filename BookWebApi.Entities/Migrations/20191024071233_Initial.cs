using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookWebApi.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    YearOfPublish = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "IsDeleted", "Title", "YearOfPublish" },
                values: new object[,]
                {
                    { 1, false, "The Mahabharata Secret", 2015 },
                    { 2, false, "The Alexander Secret: Book 1 of the Mahabharata Quest Series", 2011 },
                    { 3, false, "The Mini Sequel to The Alexander Secret: A Secret Revealed ", 2009 },
                    { 4, false, "The Secret of the Druids", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BookId", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 1, 2, "Daniel", false, "Howard" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BookId", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 2, 2, "Rose", false, "Smith" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookId",
                table: "Authors",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
