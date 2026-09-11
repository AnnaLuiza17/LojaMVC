using LojaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaMVCTests
{
    public class ProdutoTests
    {
        [Fact]
        public void ValorProduto_Maior_que_Zero()
        {
            //Arrange
            var produto = new Produto
            {
                Nome = "Mouse",
                Preco = 0,
                Estoque = 50
            };

            //Act
            var resultado = produto.Validation();

            //Assert 
            Assert.False(resultado);
        }

        [Fact]
        public void Estoque_Invalido_Quando_For_Negativo()
        {
            //Arrange
            var produto = new Produto
            {
                Nome = "Teclado",
                Preco = 50,
                Estoque = -1
            };

            //Act 
            var resultado = produto.Validation();

            //Assert 
            Assert.False(resultado);
        }

        [Fact]
        public void Nome_Invalido_Se_Vazio_Ou_Nulo()
        {
            //Arrange 
            var produto = new Produto
            {
                Nome = "",
                Preco = 50,
                Estoque = 10
            };

            //Act 
            var resultado = produto.Validation();

            //Assert 
            Assert.False(resultado);
        }

        public void VerificaNome_Valido_Verifica_Preco_Valido_Verifica_Estoque_Valido()
        {
            //Arrange 
            var produto = new Produto
            {
                Nome = "Monitor",
                Preco = 50,
                Estoque = 10
            };

            //Act 
            var resultado = produto.Validation();

            //Assert 
            Assert.True(resultado);
        }
    }
}
