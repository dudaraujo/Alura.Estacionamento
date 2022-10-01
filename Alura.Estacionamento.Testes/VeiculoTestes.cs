using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {

        [Fact (DisplayName = "Teste nº1")]
        [Trait ("Funcionalidade", "Acelerar")]
        public void ValidaVeiculoAcelerar()
        {
            //Arrange - Preparação do cenário
            var veiculo = new Veiculo();
            //Act - Execução do teste
            veiculo.Acelerar(10);
            //Assert - Conferindo resultado esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void ValidaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void ValidaTipoVeiculo()
        {
            var veiculo = new Veiculo();
            //Verificando se a propriedade TipoVeiculo, está setando automaticamente o tipo Automovel,
            //quando criamos um objeto e não informamos o tipo.
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact (DisplayName = "Teste ignorado", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void ValidaDadosveiculo()
        {
            var carro = new Veiculo();
            carro.Proprietario = "Josy Araujo";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "tyu-5675";
            carro.Cor = "Verde";
            carro.Modelo = "x1";

            string dados = carro.ToString();

            Assert.Contains("Ficha do Veiculo:", dados);
        }
    }
}
