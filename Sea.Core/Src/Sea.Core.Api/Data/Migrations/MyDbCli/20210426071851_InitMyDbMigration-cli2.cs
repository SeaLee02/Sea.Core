using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sea.Core.Api.Data.Migrations.MyDbCli
{
    public partial class InitMyDbMigrationcli2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "View_Sys_User");
        }
    }
}
