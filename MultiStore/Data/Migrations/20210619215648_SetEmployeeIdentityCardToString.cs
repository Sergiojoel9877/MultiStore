using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiStore.Data.Migrations
{
    public partial class SetEmployeeIdentityCardToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityCard",
                table: "Employees",
                type: "TEXT",
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldFixedLength: true,
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdentityCard",
                table: "Employees",
                type: "INTEGER",
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldFixedLength: true,
                oldMaxLength: 11);
        }
    }
}
