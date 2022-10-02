using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado");
            veiculo = new Veiculo();
        }

        [Fact (DisplayName = "Validação VeiculoAcelerarComParametro10")]
        [Trait ("Funcionalidade", "Acelerar")]
        public void ValidaVeiculoAcelerarComParametro10()
        {
            //Arrange - Preparação do cenário
            //var veiculo = new Veiculo();
            //Act - Execução do teste
            veiculo.Acelerar(10);
            //Assert - Conferindo resultado esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void ValidaVeiculoFrearComParametro10()
        {
            //var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void ValidaTipoVeiculo()
        {
            //var veiculo = new Veiculo();
            //Verificando se a propriedade TipoVeiculo, está setando automaticamente o tipo Automovel,
            //quando criamos um objeto e não informamos o tipo.
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact (DisplayName = "Teste ignorado", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
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

        [Fact]
        public void ValidaNomeProprietarioComMenosDeTresLetras()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<System.FormatException> (
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void ValidaQuartoCarcterDaPlaca()
        {
            string placa = "Abt12345";

            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void ValidaUltimosNumeroDaPlaca()
        {
            string placa = "qwe-rtyi";

            var mensagem = Assert.Throws<System.FormatException>(
                    () => new Veiculo().Placa = placa
                );

            Assert.Equal("Do 5º ao 8º caractere deve-se ter um número!", mensagem.Message);
        }
    }
}
