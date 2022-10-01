using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            //Passando o resultado esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }
    }
}
