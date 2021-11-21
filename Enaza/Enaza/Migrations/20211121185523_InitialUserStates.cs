using Microsoft.EntityFrameworkCore.Migrations;

namespace Enaza.Migrations
{
    public partial class InitialUserStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserStates",
                columns: new[] {"UserStateId", "Code", "Description"},
                values: new object[,]
                {
                    {0, "Active", "User is active and can be accessed."},
                    {1, "Blocked", "User is deleted or blocked."}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
