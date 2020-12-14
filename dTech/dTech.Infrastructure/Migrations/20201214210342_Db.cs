using Microsoft.EntityFrameworkCore.Migrations;

namespace dTech.Infrastructure.Migrations
{
    public partial class Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_PTasks_PTaskId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_PTaskId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "PTaskId",
                table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Attachments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    PTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_PTasks_PTaskId",
                        column: x => x.PTaskId,
                        principalTable: "PTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CommentId",
                table: "Attachments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PTaskId",
                table: "Comment",
                column: "PTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Comment_CommentId",
                table: "Attachments",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Comment_CommentId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CommentId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "PTaskId",
                table: "Attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_PTaskId",
                table: "Attachments",
                column: "PTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_PTasks_PTaskId",
                table: "Attachments",
                column: "PTaskId",
                principalTable: "PTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
