using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO categories(Nome,ImageUrl) VALUES ('Bebidas','bebidas.jpg')");
            mb.Sql("INSERT INTO categories(Nome,ImageUrl) VALUES ('Bebidas2','bebidas1.jpg')");
            mb.Sql("INSERT INTO categories(Nome,ImageUrl) VALUES ('Bebidas3','bebidas2.jpg')");
        }
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM categories");
        }
    }
}
