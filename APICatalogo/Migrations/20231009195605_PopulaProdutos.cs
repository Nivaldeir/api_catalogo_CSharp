using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder cmd)
        {
            cmd.Sql("INSERT INTO products (Nome, Descricao, Preco, ImageUrl, Estoque, Datacadastro, CategorieId) VALUES('Coca-Cola', 'Regri',  5.52,'coca.jpg', 10,now(), 1)");
            cmd.Sql("INSERT INTO products (Nome, Descricao, Preco, ImageUrl, Estoque, Datacadastro, CategorieId) VALUES('Coca-Cola1', 'Regri1',  5.52,'coca.jpg',10,now(), 2)");
            cmd.Sql("INSERT INTO products (Nome, Descricao, Preco, ImageUrl, Estoque, Datacadastro, CategorieId) VALUES('Coca-Cola1', 'Regri1',  5.52,'coca.jpg',10,now(), 3)");
        }

        protected override void Down(MigrationBuilder cmd)
        {
            cmd.Sql("DELETE FROM products");
        }
    }
}
