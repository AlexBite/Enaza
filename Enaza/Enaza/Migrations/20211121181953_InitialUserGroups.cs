using Microsoft.EntityFrameworkCore.Migrations;

namespace Enaza.Migrations
{
    public partial class InitialUserGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] {"UserGroupId", "Code", "Description"},
                values: new object[,]
                {
                    {0, "Admin", "Administrator user. Only one in the system. Can add or delete users."},
                    {1, "User", "Just a user. Do not have rights to add or delete users."}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
