using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise4DiggWebshop.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class ManyAddedandSections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<int>(type: "int", nullable: false),
                    BlogArticleId = table.Column<int>(type: "int", nullable: false),
                    SectionImageModuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_BlogArticles_BlogArticleId",
                        column: x => x.BlogArticleId,
                        principalTable: "BlogArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_SectionImageModules_SectionImageModuleId",
                        column: x => x.SectionImageModuleId,
                        principalTable: "SectionImageModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_BlogArticleId",
                table: "Sections",
                column: "BlogArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionImageModuleId",
                table: "Sections",
                column: "SectionImageModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "BlogArticles");
        }
    }
}
