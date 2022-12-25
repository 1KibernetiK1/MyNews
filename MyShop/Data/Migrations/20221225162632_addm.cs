using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Data.Migrations
{
    public partial class addm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Comments_CommentsCommentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CommentsCommentId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CommentsCommentId",
                table: "Articles");

            migrationBuilder.AddColumn<long>(
                name: "CommentId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CommentId",
                table: "Articles",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Comments_CommentId",
                table: "Articles",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Comments_CommentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CommentId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Articles");

            migrationBuilder.AddColumn<long>(
                name: "CommentsCommentId",
                table: "Articles",
                type: "bigint",
                nullable: true);

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
    }
}
