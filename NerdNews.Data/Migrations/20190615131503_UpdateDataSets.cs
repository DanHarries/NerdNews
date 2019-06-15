using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdNews.Data.Migrations
{
    public partial class UpdateDataSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Comments",
                newName: "CommentDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "CommentId",
                table: "Replies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CommentId",
                table: "CommentHistory",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentDateTime",
                table: "Comments",
                newName: "DateTime");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Replies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "CommentHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
