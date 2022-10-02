using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Maria Eduarda Araujo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Lamborghini";
            veiculo.Placa = "abc-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        //Trablhar com um conjunto maior de dados (parâmetros)
        [Theory]
        [InlineData("Gabril de Almeida", "cba-9876", "Roxo", "Mustang")]
        [InlineData("Isabela Beretta", "sdf-6544", "Amarelo", "Cadilac")]
        [InlineData("Davi Araújo", "dav-5647", "Azul", "Ferrari")]

        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, 
                                                       string placa, 
                                                       string cor,
                                                       string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);


        }

        [Theory]
        [InlineData("Gabril de Almeida", "cba-9876", "Roxo", "Mustang")]
        public void LocalizaVeiculoPatioComBaseNaPlaca(string proprietario,
                                         string placa,
                                         string cor,
                                         string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(placa);

            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Maria Eduarda Araujo";
            veiculo.Placa = "abc-1234";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Lamborghini";
           
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Maria Eduarda Araujo";
            veiculoAlterado.Placa = "abc-1234";
            veiculoAlterado.Cor = "Vermelho";
            veiculoAlterado.Modelo = "Lamborghini";
            

            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

    }
}
