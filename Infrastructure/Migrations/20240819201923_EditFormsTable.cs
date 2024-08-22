using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditFormsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormTypes_FormTypeId",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Forms",
                newName: "ControlName");

            migrationBuilder.AlterColumn<int>(
                name: "FormTypeId",
                table: "Forms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ControlType",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormTypes_FormTypeId",
                table: "Forms",
                column: "FormTypeId",
                principalTable: "FormTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormTypes_FormTypeId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ControlType",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "ControlName",
                table: "Forms",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "FormTypeId",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormTypes_FormTypeId",
                table: "Forms",
                column: "FormTypeId",
                principalTable: "FormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
