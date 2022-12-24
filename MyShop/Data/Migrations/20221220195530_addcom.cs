using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class addcom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CommentsCommentId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CommentsCommentId",
                table: "Articles",
                column: "CommentsCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Comments_CommentsCommentId",
                table: "Articles",
                column: "CommentsCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Comments_CommentsCommentId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CommentsCommentId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CommentsCommentId",
                table: "Articles");
        }
    }
}
