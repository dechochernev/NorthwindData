using Microsoft.EntityFrameworkCore.Migrations;

namespace Access.EntityFramework.Migrations
{
    public partial class AlterTopTenMostExpensiveProductsStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER procedure [dbo].[Ten Most Expensive Products] AS " +
                "SET ROWCOUNT 10 " +
                "SELECT Products.ProductID, Products.ProductName, Products.UnitPrice " +
                "FROM Products " +
                "ORDER BY Products.UnitPrice DESC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER procedure [dbo].[Ten Most Expensive Products] AS " +
                "SET ROWCOUNT 10 " +
                "SELECT Products.ProductName AS TenMostExpensiveProducts, Products.UnitPrice " +
                "FROM Products " +
                "ORDER BY Products.UnitPrice DESC");
        }
    }
}
