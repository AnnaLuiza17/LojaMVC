using LojaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaMVCTests
{
    public class ClienteTests
    {
        [Fact]
        public void Idade_Invalida_Quando_Menor_Que_18()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Lucas Silva",
                Email = "lucassilva@gmail.com",
                Idade = 17,
                Ativo = true
            };

            //Act
            var resultado = cliente.Validation();

            //Assert 
            Assert.False(resultado);
        }

        [Fact]
        public void Email_Invalido_Quando_Nao_Possuir_Arroba()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Luana Carvalho",
                Email = "luanacarvalhogmail.com",
                Idade = 20, 
                Ativo = true
            };

            //Act
            var resultado = cliente.Validation();

            //Assert 
            Assert.False(resultado);

        }

        [Fact]
        public void Nome_Invalido_Se_Vazio_Ou_Nulo()
        {
            //Arrange
            var cliente = new Cliente 
            {   
                Nome = "", 
                Email = "luanacarvalho@email.com", 
                Idade = 20, 
                Ativo = true 
            };

            //Act
            var resultado = cliente.Validation();

            //Assert
            Assert.False(resultado); 
        }

        [Fact]
        public void Cliente_Inativo_Nao_Pode_Realizar_Compra()
        {
            //Arrange
            var cliente = new Cliente 
            { 
              Nome = "Carlos Andorinha", 
              Email = "carlosandorinha@email.com", 
              Idade = 30, 
              Ativo = false 
            };

            //Act
            var resultado = cliente.Permission() && cliente.Validation();

            //Assert 
            Assert.False(resultado); 
        }

        [Fact]
        public void Cliente_Ativo_E_Maior_De_Idade_Pode_Comprar()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Fernanda Castro",
                Email = "fernandocastro@gmail.com",
                Idade = 22,
                Ativo = true
            };

            //Act
            var resultado = cliente.Permission() && cliente.Validation();

            //Assert 
            Assert.True(resultado);
        }


        [Fact]
        public void Validar_Todos_Os_Cenarios_Do_Cliente()
        {
            // === CENÁRIO 1: Idade menor que 18 deve ser inválido ===
            var clienteMenorIdade = new Cliente { Nome = "Lucas Silva", Email = "lucassilva@email.com", Idade = 17, Ativo = true };
            Assert.False(clienteMenorIdade.Validation());

            // === CENÁRIO 2: E-mail sem @ deve ser inválido ===
            var clienteEmailInvalido = new Cliente { Nome = "Luana Carvalho", Email = "luanacarvalhogmail.com", Idade = 20, Ativo = true };
            Assert.False(clienteEmailInvalido.Validation());

            // === CENÁRIO 3: Nome vazio deve ser inválido ===
            var clienteSemNome = new Cliente { Nome = "", Email = "luanacarvalho@email.com", Idade = 20, Ativo = true };
            Assert.False(clienteSemNome.Validation());

            // === CENÁRIO 4: Cliente inativo não pode realizar compra ===
            var clienteInativo = new Cliente { Nome = "Carlos Andorinha", Email = "carlosandorinha@email.com", Idade = 30, Ativo = false };
            Assert.False(clienteInativo.Permission());

            // === CENÁRIO 5: Cliente ativo e maior de idade pode comprar ===
            var clienteApto = new Cliente { Nome = "Fernanda Castro", Email = "fernandacastro@email.com", Idade = 22, Ativo = true };
            Assert.True(clienteApto.Permission());
        }
    }
}
