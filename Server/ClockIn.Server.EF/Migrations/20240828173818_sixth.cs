using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClockIn.Server.EF.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "eat off",
                table: "sys_user_info",
                newName: "eat_off");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "eat_off",
                table: "sys_user_info",
                newName: "eat off");
        }
    }
}
