using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("PRAGMA recursive_triggers = 0");
            string sql=@"
                        CREATE TRIGGER UpdateCustomerVersion
                        AFTER UPDATE ON Customers
                        BEGIN
                            UPDATE Customers
                            SET RowVersion = RowVersion + 1
                            WHERE rowid = NEW.rowid;
                        END; ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = @"DROP TRIGGER UpdateCustomerVersion";
            migrationBuilder.Sql(sql);
        }
    }
}
