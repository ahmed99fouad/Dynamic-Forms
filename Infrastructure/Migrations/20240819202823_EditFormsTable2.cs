using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditFormsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormTypes_FormTypeId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "FormTypes");

            migrationBuilder.DropIndex(
                name: "IX_Forms_FormTypeId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FormTypeId",
                table: "Forms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormTypeId",
                table: "Forms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FormTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_FormTypeId",
                table: "Forms",
                column: "FormTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormTypes_FormTypeId",
                table: "Forms",
                column: "FormTypeId",
                principalTable: "FormTypes",
                principalColumn: "Id");
        }
    }
}
