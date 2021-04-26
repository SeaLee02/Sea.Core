using Microsoft.EntityFrameworkCore.Migrations;

namespace Sea.Core.Api.Data.Migrations.MyDbCli
{
    public partial class InitMyDbMigrationcli3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CS",
                table: "Sys_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CS",
                table: "Sys_User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "测试");
        }
    }
}
